using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Orders;
using MAS_DeliveryService.Api.Domain.PackageItems;
using Microsoft.EntityFrameworkCore;

namespace MAS_DeliveryService.Api.Domain.Packages;

[Index(nameof(SerialNumber), IsUnique = true)]
public class Package
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string SerialNumber { get; set; }

    [Length(1, 500)]
    public string? Comment { get; set; }

    public decimal Weight => PackageItems.Sum(pi => pi.Package.Weight);

    public Guid SentInId { get; set; }

    [ForeignKey(nameof(SentInId))]
    public virtual Order SentIn { get; set; }

    public Guid? DeliveredInId { get; set; }

    [ForeignKey(nameof(DeliveredInId))]
    public virtual Order? DeliveredIn { get; set; }

    public virtual ICollection<PackageItem> PackageItems { get; set; }
}