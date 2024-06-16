using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.Exceptions;
using MAS_DeliveryService.Api.Domain.PackageItems;
using MAS_DeliveryService.Api.Domain.Packages;
using Microsoft.EntityFrameworkCore;

namespace MAS_DeliveryService.Api.Repositories;

public class PackageRepository : IPackageRepository
{
    private readonly Context _context;

    public PackageRepository(Context context)
    {
        _context = context;
    }

    public async Task AddPackages(IEnumerable<Package> packages, List<PackageItem> packageItems)
    {
        if (!packageItems.Any() || packageItems is null)
            throw new EmptyCollectionException("Package must contain at least 1 item");
        var orderItems = await _context.OrderItems.Where(oi => oi.OrderId == packages.First().SentInId).ToListAsync();
        
        if (!packageItems.All(pi => orderItems.Select(oi => oi.ItemId).Contains(pi.ItemId)))
            throw new Exception("Package cannot contain not ordered items");

        await _context.Packages.AddRangeAsync(packages);
        await _context.PackageItems.AddRangeAsync(packageItems);
        await _context.SaveChangesAsync();
    }
}