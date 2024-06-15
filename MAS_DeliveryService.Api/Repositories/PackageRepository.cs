using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.Exceptions;
using MAS_DeliveryService.Api.Domain.PackageItems;
using MAS_DeliveryService.Api.Domain.Packages;

namespace MAS_DeliveryService.Api.Repositories;

public class PackageRepository : IPackageRepository
{
    private readonly Context _context;

    public PackageRepository(Context context)
    {
        _context = context;
    }

    public async Task AddPackage(Package package)
    {
        await _context.Packages.AddAsync(package);
        await _context.SaveChangesAsync();
    }
    
    public async Task AddPackages(IEnumerable<Package> packages, List<PackageItem> packageItems)
    {
        if (!packageItems.Any()) throw new EmptyCollectionException("Package must contain at least 1 item");
        await _context.Packages.AddRangeAsync(packages);
        await _context.PackageItems.AddRangeAsync(packageItems);
        await _context.SaveChangesAsync();
    }
}