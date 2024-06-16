using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Clients;
using MAS_DeliveryService.Api.Domain.Deliveries;
using MAS_DeliveryService.Api.Domain.Items;
using MAS_DeliveryService.Api.Domain.OrderItems;
using MAS_DeliveryService.Api.Domain.Packages;
using MAS_DeliveryService.Api.Domain.Validators;

namespace MAS_DeliveryService.Api.Domain.Orders;

public class Order
{
    public Order(string sender, string destination, Guid clientId)
    {
        Id = Guid.NewGuid();
        Sender = sender;
        Destination = destination;
        ClientId = clientId;
        IsCancelled = false;
    }

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
            if (IsCancelled) return "Canceled";
            if (Delivery?.DateTo is not null && SentIn.Any(p => p.DeliveredIn is null)) return "Incomplete";
            if (Delivery?.DateTo is not null) return "Delivered";
            if (Delivery is not null) return "Sent";
            if (SentIn.Any()) return "Awaiting delivery";
            return "Pending";
        } 
    }

    [Required]
    public bool IsCancelled { get; set; }
    
    [InverseProperty(nameof(SentIn))]
    public virtual ICollection<Package> SentIn { get; set; }

    [InverseProperty(nameof(DeliveredIn))]
    public virtual ICollection<Package> DeliveredIn { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }

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

    public List<Item> GetItems()
    {
        return OrderItems.Select(oi => oi.Item).OrderBy(i => i.Weight).ToList();
    }
}