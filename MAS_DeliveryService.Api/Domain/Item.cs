using System.ComponentModel.DataAnnotations;

namespace MAS_DeliveryService.Api.Domain;

public class Item
{
    [Key]
    public Guid Id { get; set; }
    
    [Required, Length(1, 300)]
    public string Name { get; set; }
    
    [Required, Range(0.01, double.MaxValue)]
    public decimal Weight { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
    
    public virtual ICollection<Package> Packages { get; set; }
}