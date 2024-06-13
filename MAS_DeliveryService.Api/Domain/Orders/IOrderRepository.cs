using MAS_DeliveryService.Api.Domain.Orders.DTOs;

namespace MAS_DeliveryService.Api.Domain.Orders;

public interface IOrderRepository
{
    public Task CreateOrder(Order order);
    public Task<List<OrderGetResponse>> GetPendingOrders();
    public Task<Order> ReadOrder(Guid id);
    public Task DeleteOrder(Order order);
    
    public Task<bool> OrderExists(Guid id);
}