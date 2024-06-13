using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Items;
using MAS_DeliveryService.Api.Domain.Packages;

namespace MAS_DeliveryService.Api.Domain.PackageItems;

public class PackageItem
{
    [Key]
    public Guid Id { get; set; }

    public Guid ItemId { get; set; }

    [ForeignKey(nameof(ItemId))]
    public virtual Item Item { get; set; }

    public Guid PackageId { get; set; }

    [ForeignKey(nameof(PackageId))] 
    public virtual Package Package { get; set; }
}