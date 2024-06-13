namespace MAS_DeliveryService.Api.Domain.OrderItems;

public interface IOrderItemRepository
{
    public Task CreateOrderItem(OrderItem orderItem);
    public Task<List<OrderItem>> ReadOrderItems();
    public Task<OrderItem> ReadOrderItem(Guid id);
    public Task DeleteOrderItem(OrderItem orderItem);
    public Task<bool> OrderItemExists(Guid id);    
}