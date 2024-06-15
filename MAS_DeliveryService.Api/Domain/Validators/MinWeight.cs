using System.ComponentModel.DataAnnotations;

namespace MAS_DeliveryService.Api.Domain.Validators;

[AttributeUsage(AttributeTargets.Property)]
public class MinWeight : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not decimal weight) return new ValidationResult("Value must be decimal");
        return weight > 0m ? ValidationResult.Success : new ValidationResult("Value must be higher than 0");
    }
}