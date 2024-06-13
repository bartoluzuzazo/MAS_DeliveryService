using MAS_DeliveryService.Api.Domain.Items.DTOs;

namespace MAS_DeliveryService.Api.Domain.Orders.DTOs;

public class OrderGetResponse
{
    public Guid Id { get; set; }
    public string Sender { get; set; }
    public string Destination { get; set; }
    public List<ItemGetResponse> Items { get; set; }
    public string ClientFirstName { get; set; }
    public string ClientLastName { get; set; }
}