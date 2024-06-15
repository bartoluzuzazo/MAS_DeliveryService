using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAS_DeliveryService.Api.Domain.Couriers;
using MAS_DeliveryService.Api.Domain.Enums;

namespace MAS_DeliveryService.Api.Domain.DriversLicenses;

public class DriversLicense
{
    public DriversLicense(DateTime dateIssued, HashSet<LicenseCategory> categories, Guid courierId)
    {
        DateIssued = dateIssued;
        Categories = categories;
        CourierId = courierId;
    }

    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public DateTime DateIssued { get; set; }
    
    public HashSet<LicenseCategory> Categories { get; set; }
    
    public Guid CourierId { get; set; }
    
    [ForeignKey(nameof(CourierId))]
    public virtual Courier Courier { get; set; }
}