namespace MAS_DeliveryService.Api.Domain.PackageItems;

public interface IPackageItemRepository
{
    public Task AddPackageItem(PackageItem packageItem);
}