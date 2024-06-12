using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MAS_DeliveryService.Api.Domain;

[Index(nameof(CourierId), nameof(OrderId), IsUnique = true)]
public class Delivery
{
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