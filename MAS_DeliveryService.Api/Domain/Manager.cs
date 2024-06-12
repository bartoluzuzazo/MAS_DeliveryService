using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_DeliveryService.Api.Domain;

[Table(nameof(Manager))]
public class Manager : Worker
{
    [Required, Length(1, 500)]
    public string Education { get; set; }
}