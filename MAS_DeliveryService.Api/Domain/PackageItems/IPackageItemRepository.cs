namespace MAS_DeliveryService.Api.Domain.PackageItems;

public interface IPackageItemRepository
{
    public Task AddPackageItem(PackageItem packageItem);
    public Task AddPackageItems(IEnumerable<PackageItem> packageItems);
}