namespace MAS_DeliveryService.Api.Domain.Exceptions;

public class TooHeavyException : Exception
{
    public TooHeavyException(string? message) : base(message)
    {
    }
}