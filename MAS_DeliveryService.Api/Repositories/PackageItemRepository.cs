using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.PackageItems;

namespace MAS_DeliveryService.Api.Repositories;

public class PackageItemRepository : IPackageItemRepository
{
    private readonly Context _context;

    public PackageItemRepository(Context context)
    {
        _context = context;
    }

    public async Task AddPackageItem(PackageItem packageItem)
    {
        await _context.PackageItems.AddAsync(packageItem);
        await _context.SaveChangesAsync();
    }
    
    public async Task AddPackageItems(IEnumerable<PackageItem> packageItems)
    {
        await _context.PackageItems.AddRangeAsync(packageItems);
        await _context.SaveChangesAsync();
    }
}