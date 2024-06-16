using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.DriversLicenses;

namespace MAS_DeliveryService.Api.Repositories;

public class DriversLicenseRepository : IDriversLicenseRepository
{
    private readonly Context _context;

    public DriversLicenseRepository(Context context)
    {
        _context = context;
    }

    public async Task AddLicense(DriversLicense license)
    {
        await _context.DriversLicenses.AddAsync(license);
        await _context.SaveChangesAsync();
    }
}