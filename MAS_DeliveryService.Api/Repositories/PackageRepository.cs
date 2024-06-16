using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.Exceptions;
using MAS_DeliveryService.Api.Domain.PackageItems;
using MAS_DeliveryService.Api.Domain.Packages;
using MAS_DeliveryService.Api.Domain.Static;
using Microsoft.EntityFrameworkCore;

namespace MAS_DeliveryService.Api.Repositories;

public class PackageRepository : IPackageRepository
{
    private readonly Context _context;
    private readonly IStaticRepository _static;

    public PackageRepository(Context context, IStaticRepository @static)
    {
        _context = context;
        _static = @static;
    }

    public async Task AddPackages(List<Package> packages, List<PackageItem> packageItems)
    {
        if (!packageItems.Any() || packageItems is null)
            throw new EmptyCollectionException("Package must contain at least 1 item");
        var orderItems = await _context.OrderItems.Where(oi => oi.OrderId == packages.First().SentInId).ToListAsync();

        if (!packageItems.All(pi => orderItems.Select(oi => oi.ItemId).Contains(pi.ItemId)))
            throw new Exception("Package cannot contain not ordered items");

        var maxW = await _static.GetMaxWeight();
        foreach (var package in packages)
        {
            var associations = packageItems.Where(pi => pi.PackageId == package.Id);
            var itemWeights = await _context.Items
                .Where(i => associations.Select(pi => pi.ItemId)
                .Any(id => id == i.Id))
                .Select(i => i.Weight).ToListAsync();
            if (itemWeights.Sum() > maxW) throw new TooHeavyException($"Package {package.Id} exceeds the limit of {maxW}kg.");
        }

        await _context.Packages.AddRangeAsync(packages);
        await _context.PackageItems.AddRangeAsync(packageItems);
        await _context.SaveChangesAsync();
    }
}