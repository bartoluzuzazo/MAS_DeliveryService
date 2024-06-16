namespace MAS_DeliveryService.Api.Domain.Orders;

public interface IOrderRepository
{
    /// <summary>
    /// Metoda służąca do dodania nowego zamówienia do bazy danych. 
    /// </summary>
    /// <param name="order">Nowe zamówienie</param>
    /// <param name="itemIds">Identyfikatory zamówionych przedmiotów</param>
    /// <returns></returns>
    public Task CreateOrder(Order order, List<Guid> itemIds);
    
    /// <summary>
    /// Metoda służąca do odczytu wszystkich oczekujących zamówień z bazy danych.
    /// </summary>
    /// <returns>Lista zamówień o statusie "Pending"</returns>
    public Task<List<Order>> GetPendingOrders();
}