namespace MAS_DeliveryService.Api.Domain.Items.DTOs;

public class ItemGetResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Weight { get; set; }
}