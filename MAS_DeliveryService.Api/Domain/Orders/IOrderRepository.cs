using MAS_DeliveryService.Api.Domain.Orders.DTOs;

namespace MAS_DeliveryService.Api.Domain.Orders;

public interface IOrderRepository
{
    public Task CreateOrder(Order order, List<Guid> itemIds);
    public Task<List<OrderGetResponse>> GetPendingOrders();
}