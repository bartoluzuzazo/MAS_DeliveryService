using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Items;
using MAS_DeliveryService.Api.Domain.Orders;

namespace MAS_DeliveryService.Api.Domain.OrderItems;

public class OrderItem
{
    public OrderItem(Guid orderId, Guid itemId)
    {
        Id = Guid.NewGuid();
        OrderId = orderId;
        ItemId = itemId;
    }

    [Key]
    public Guid Id { get; set; }
    
    public Guid OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; }
    
    public Guid ItemId { get; set; }

    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; }
}