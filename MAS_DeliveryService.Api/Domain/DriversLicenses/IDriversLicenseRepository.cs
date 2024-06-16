namespace MAS_DeliveryService.Api.Domain.DriversLicenses;

public interface IDriversLicenseRepository
{
    public Task AddLicense(DriversLicense license);
}