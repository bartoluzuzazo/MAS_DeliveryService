namespace MAS_DeliveryService.Api.Domain.Packages;

public interface IPackageRepository
{
    public Task AddPackage(Package package);
}