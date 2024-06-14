using MAS_DeliveryService.Api.Contexts;
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
    
    public async Task AddPackages(IEnumerable<Package> packages)
    {
        await _context.Packages.AddRangeAsync(packages);
        await _context.SaveChangesAsync();
    }
}