namespace MAS_DeliveryService.Api.Domain.Deliveries;

public interface IDeliveryRepository
{
    public Task AddDelivery(Delivery delivery);
    public Task<Delivery?> GetDelivery(Guid deliveryId);
    public Task<List<Delivery>> GetDeliveries();
}