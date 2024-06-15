using MAS_DeliveryService.Api.Domain.PackageItems;

namespace MAS_DeliveryService.Api.Domain.Packages;

public interface IPackageRepository
{
    public Task AddPackages(IEnumerable<Package> packages, List<PackageItem> packageItems);
}