using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Orders;
using MAS_DeliveryService.Api.Domain.People;

namespace MAS_DeliveryService.Api.Domain.Clients;

[Table(nameof(Client))]
public class Client
{
    [Key] 
    public Guid Id { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    public virtual ICollection<Order> Orders { get; set; }

    public Guid PersonId { get; set; }
    
    [ForeignKey(nameof(PersonId))]    
    public virtual Person Person { get; set; }
}