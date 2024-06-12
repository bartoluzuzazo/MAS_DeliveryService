using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_DeliveryService.Api.Domain;

public class Order
{
    [Key]
    public Guid Id { get; set; }
    
    [Required, Length(1, 300)]
    public string Sender { get; set; }

    [Required, Length(1, 300)]
    public string Destination { get; set; }

    public string State
    {
        get
        {
            if (Delivery?.DateTo is not null && SentIn.Any(p => p.DeliveredIn is null)) return "Incomplete";
            if (Delivery?.DateTo is not null) return "Delivered";
            if (Delivery is not null) return "Sent";
            if (SentIn.Any()) return "Awaiting delivery";
            if (IsCancelled) return "Canceled";
            return "Pending";
        } 
    }

    [Required]
    public bool IsCancelled { get; set; }
    
    [InverseProperty(nameof(SentIn))]
    public virtual ICollection<Package> SentIn { get; set; }

    [InverseProperty(nameof(DeliveredIn))]
    public virtual ICollection<Package> DeliveredIn { get; set; }

    public virtual ICollection<Item> Items { get; set; }

    public Guid ClientId { get; set; }
    
    [ForeignKey(nameof(ClientId))]
    public virtual Client Client { get; set; }
    
    public Guid? DeliveryId { get; set; }

    [ForeignKey(nameof(DeliveryId))]
    public virtual Delivery? Delivery { get; set; }

    public void CancelOrder()
    {
        if (State == "Pending") IsCancelled = true;
    }
}