using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Workers;

namespace MAS_DeliveryService.Api.Domain.Managers;

[Table(nameof(Manager))]
public class Manager : Worker
{
    [Required, Length(1, 500)]
    public string Education { get; set; }
}