using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.Static;
using Microsoft.EntityFrameworkCore;

namespace MAS_DeliveryService.Api.Repositories;

public class StaticRepository : IStaticRepository
{
    private readonly Context _context;

    public StaticRepository(Context context)
    {
        _context = context;
    }

    public async Task SetStatic(Static @static)
    {
        _context.Static.RemoveRange(await _context.Static.ToListAsync());
        await _context.Static.AddAsync(@static);
        await _context.SaveChangesAsync();
    }

    public async Task<decimal> GetMaxWeight()
    {
        return await _context.Static.Select(s => s.MaxWeight).FirstAsync();
    }

    public async Task<int> GetYearlyVacationDays()
    {
        return await _context.Static.Select(s => s.YearlyVacationDays).FirstAsync();
    }
}