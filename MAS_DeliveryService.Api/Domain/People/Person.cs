using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Clients;
using MAS_DeliveryService.Api.Domain.Workers;

namespace MAS_DeliveryService.Api.Domain.People;

[Table(nameof(Person))]
public class Person
{
    [Key]
    public Guid Id { get; set; }
    
    [Required, MinLength(1), MaxLength(200)]
    public string FirstName { get; set; }
    
    [Required, MinLength(1), MaxLength(200)]
    public string LastName { get; set; }
    
    [Required, Phone]
    public string Number { get; set; }

    public Guid? ClientId { get; set; }
    
    [ForeignKey(nameof(ClientId))]    
    public virtual Client? Client { get; set; }
    
    public Guid? WorkerId { get; set; }
    
    [ForeignKey(nameof(WorkerId))]    
    public virtual Worker? Worker { get; set; }
}