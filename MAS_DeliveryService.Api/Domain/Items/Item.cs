using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.OrderItems;
using MAS_DeliveryService.Api.Domain.PackageItems;
using MAS_DeliveryService.Api.Domain.Validators;

namespace MAS_DeliveryService.Api.Domain.Items;

public class Item
{
    public Item(string name, decimal weight)
    {
        Name = name;
        Weight = weight;
    }

    [Key]
    public Guid Id { get; set; }
    
    [Required, Length(1, 300)]
    public string Name { get; set; }
    
    [Required, MinWeight]
    public decimal Weight { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }
    
    public virtual ICollection<PackageItem> PackageItems { get; set; }
}