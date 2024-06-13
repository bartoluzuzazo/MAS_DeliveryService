namespace MAS_DeliveryService.Api.Domain.Orders.DTOs;

public class OrderPostRequest
{
    public string Sender { get; set; }
    public string Destination { get; set; }
    public Guid ClientId { get; set; }
    public List<Guid> ItemIds { get; set; }
}