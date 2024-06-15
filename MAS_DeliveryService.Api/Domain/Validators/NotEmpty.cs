using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MAS_DeliveryService.Api.Domain.Validators;

[AttributeUsage(AttributeTargets.Property)]
public class NotEmpty : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not ICollection enumerable) return new ValidationResult("Value must be enumerable");
        return enumerable.Count > 0 ? ValidationResult.Success : new ValidationResult($"{validationContext.MemberName} cannot be empty");
    }
}