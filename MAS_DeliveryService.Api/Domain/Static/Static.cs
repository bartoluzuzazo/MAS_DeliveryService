using System.ComponentModel.DataAnnotations;

namespace MAS_DeliveryService.Api.Domain.Static;

public class Static
{
    public Static(decimal maxWeight, int yearlyVacationDays)
    {
        Id = Guid.NewGuid();
        MaxWeight = maxWeight;
        YearlyVacationDays = yearlyVacationDays;
    }

    [Key]
    public Guid Id { get; set; }
    [Required]
    public decimal MaxWeight { get; set; }
    [Required]
    public int YearlyVacationDays { get; set; }
}