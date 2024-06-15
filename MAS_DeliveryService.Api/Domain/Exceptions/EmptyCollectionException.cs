namespace MAS_DeliveryService.Api.Domain.Exceptions;

public class EmptyCollectionException : Exception
{
    public EmptyCollectionException(string? message) : base(message)
    {
    }
}