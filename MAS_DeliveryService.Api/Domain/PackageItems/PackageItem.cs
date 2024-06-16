using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Items;
using MAS_DeliveryService.Api.Domain.Packages;
using Microsoft.EntityFrameworkCore;

namespace MAS_DeliveryService.Api.Domain.PackageItems;

[Index(nameof(ItemId), nameof(PackageId), IsUnique = true)]
public class PackageItem
{
    public PackageItem(Guid itemId, Guid packageId)
    {
        Id = Guid.NewGuid();
        ItemId = itemId;
        PackageId = packageId;
    }

    [Key]
    public Guid Id { get; set; }

    public Guid ItemId { get; set; }

    [ForeignKey(nameof(ItemId))]
    public virtual Item Item { get; set; }

    public Guid PackageId { get; set; }

    [ForeignKey(nameof(PackageId))] 
    public virtual Package Package { get; set; }
}