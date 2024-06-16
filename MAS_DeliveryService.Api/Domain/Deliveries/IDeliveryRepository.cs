namespace MAS_DeliveryService.Api.Domain.Deliveries;

public interface IDeliveryRepository
{
    public Task AddDelivery(Delivery delivery);
}