using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_DeliveryService.Api.Domain;

[Table(nameof(Courier))]
public class Courier : Worker
{
    public Guid DriversLicenseId { get; set; }

    [ForeignKey(nameof(DriversLicenseId))]
    public DriversLicense DriversLicense { get; set; }
    
    public virtual ICollection<Delivery> Deliveries { get; set; }
}