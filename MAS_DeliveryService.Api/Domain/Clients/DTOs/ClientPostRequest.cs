namespace MAS_DeliveryService.Api.Domain.Clients.DTOs;

public class ClientPostRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Number { get; set; }
    public string Email { get; set; }
}