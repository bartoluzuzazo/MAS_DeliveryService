using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.Deliveries;

namespace MAS_DeliveryService.Api.Repositories;

public class DeliveryRepository : IDeliveryRepository
{
    private readonly Context _context;

    public DeliveryRepository(Context context)
    {
        _context = context;
    }

    public async Task AddDelivery(Delivery delivery)
    {
        await _context.Deliveries.AddAsync(delivery);
        await _context.SaveChangesAsync();
    }
}