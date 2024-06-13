using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.OrderItems;

namespace MAS_DeliveryService.Api.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly Context _context;

    public OrderItemRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateOrderItem(OrderItem orderItem)
    {
        await _context.OrderItems.AddAsync(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task<List<OrderItem>> ReadOrderItems()
    {
        throw new NotImplementedException();
    }

    public async Task<OrderItem> ReadOrderItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteOrderItem(OrderItem orderItem)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> OrderItemExists(Guid id)
    {
        throw new NotImplementedException();
    }
}