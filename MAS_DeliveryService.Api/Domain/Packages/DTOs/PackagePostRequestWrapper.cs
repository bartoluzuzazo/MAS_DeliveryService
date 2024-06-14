namespace MAS_DeliveryService.Api.Domain.Packages.DTOs;

public class PackagePostRequestWrapper
{
    public List<PackagePostRequest> Packages { get; set; }
    public Guid OrderId { get; set; }
}