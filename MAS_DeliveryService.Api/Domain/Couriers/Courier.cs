using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Deliveries;
using MAS_DeliveryService.Api.Domain.DriversLicenses;
using MAS_DeliveryService.Api.Domain.Workers;

namespace MAS_DeliveryService.Api.Domain.Couriers;

[Table(nameof(Courier))]
public class Courier : Worker
{
    public Guid DriversLicenseId { get; set; }

    [ForeignKey(nameof(DriversLicenseId))]
    public DriversLicense DriversLicense { get; set; }
    
    public virtual ICollection<Delivery> Deliveries { get; set; }
}