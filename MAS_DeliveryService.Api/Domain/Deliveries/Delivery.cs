using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Couriers;
using MAS_DeliveryService.Api.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace MAS_DeliveryService.Api.Domain.Deliveries;

[Index(nameof(CourierId), nameof(OrderId), IsUnique = true)]
public class Delivery
{
    public Delivery(Guid courierId, Guid orderId)
    {
        Id = Guid.NewGuid();
        CourierId = courierId;
        OrderId = orderId;
    }

    [Key]
    public Guid Id { get; set; }
    
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    
    public Guid CourierId { get; set; }
    
    [ForeignKey(nameof(CourierId))]
    public virtual Courier Courier { get; set; }
    
    public Guid OrderId { get; set; }
    
    [ForeignKey(nameof(OrderId))]
    public virtual Order Order { get; set; }
}