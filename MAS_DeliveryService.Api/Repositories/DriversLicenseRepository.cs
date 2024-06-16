using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.DriversLicenses;
using Microsoft.EntityFrameworkCore;

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

    public async Task<DriversLicense?> GetLicense(Guid licenseId)
    {
        return await _context.DriversLicenses.FirstOrDefaultAsync(l => l.Id == licenseId);
    }

    public async Task<List<DriversLicense>> GetLicenses()
    {
        return await _context.DriversLicenses.ToListAsync();
    }

}