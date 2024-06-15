using MAS_DeliveryService.Api.Contexts;
using MAS_DeliveryService.Api.Domain.Exceptions;
using MAS_DeliveryService.Api.Domain.Items.DTOs;
using MAS_DeliveryService.Api.Domain.OrderItems;
using MAS_DeliveryService.Api.Domain.Orders;
using MAS_DeliveryService.Api.Domain.Orders.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MAS_DeliveryService.Api.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly Context _context;

    public OrderRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateOrder(Order order, List<Guid> itemIds)
    {
        if (!itemIds.Any()) throw new EmptyCollectionException("Order must contain at least 1 item");
        await _context.Orders.AddAsync(order);
        var orderItems = itemIds.Select(guid => new OrderItem(order.Id, guid)).ToList();
        await _context.OrderItems.AddRangeAsync(orderItems);
        await _context.SaveChangesAsync();
    }

    public async Task<List<OrderGetResponse>> GetPendingOrders()
    {
        var orders = _context.Orders
            .Include(o => o.SentIn)
            .Include(o => o.OrderItems).ThenInclude(oi => oi.Item)
            .Include(o => o.Client).ThenInclude(c => c.Person).ToListAsync();

        var response = await orders;
        var pending = response.Where(o => o.State == "Pending").Select(o => new OrderGetResponse()
        {
            Id = o.Id,
            Sender = o.Sender,
            Destination = o.Destination,
            Items = o.OrderItems.Select(oi => new ItemGetResponse()
            {
                Id = oi.Item.Id,
                Name = oi.Item.Name,
                Weight = oi.Item.Weight
            }).ToList(),
            ClientFirstName = o.Client.Person.FirstName,
            ClientLastName = o.Client.Person.LastName
        }).ToList();

        return pending;
    }
}