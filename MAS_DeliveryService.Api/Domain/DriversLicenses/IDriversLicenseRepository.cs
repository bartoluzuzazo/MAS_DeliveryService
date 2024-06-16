namespace MAS_DeliveryService.Api.Domain.DriversLicenses;

public interface IDriversLicenseRepository
{
    public Task AddLicense(DriversLicense license);
    public Task<DriversLicense?> GetLicense(Guid licenseId);
    public Task<List<DriversLicense>> GetLicenses();
}