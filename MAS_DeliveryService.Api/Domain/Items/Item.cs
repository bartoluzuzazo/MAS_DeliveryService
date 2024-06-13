using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.OrderItems;
using MAS_DeliveryService.Api.Domain.PackageItems;

namespace MAS_DeliveryService.Api.Domain.Items;

public class Item
{
    [Key]
    public Guid Id { get; set; }
    
    [Required, Length(1, 300)]
    public string Name { get; set; }
    
    [Required, Range(0.01, double.MaxValue)]
    public decimal Weight { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }
    
    public virtual ICollection<PackageItem> PackageItems { get; set; }
}