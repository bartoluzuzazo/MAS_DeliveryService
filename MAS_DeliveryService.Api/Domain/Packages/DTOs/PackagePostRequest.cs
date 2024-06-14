namespace MAS_DeliveryService.Api.Domain.Packages.DTOs;

public class PackagePostRequest
{
    public string Serialnumber { get; set; }
    public string Comment { get; set; }
    public List<Guid> ItemIds { get; set; }
}