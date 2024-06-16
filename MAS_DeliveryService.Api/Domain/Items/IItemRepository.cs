namespace MAS_DeliveryService.Api.Domain.Items;

public interface IItemRepository
{
    /// <summary>
    /// Metoda pozwalająca na zapis nowego przedmiotu do bazy danych. 
    /// </summary>
    /// <param name="item">Nowy przedmiot</param>
    /// <returns></returns>
    public Task CreateItem(Item item);
    public Task<List<Item>> ReadItems();
    public Task<Item> ReadItem(Guid id);
    public Task DeleteItem(Item item);
    public Task<bool> ItemExists(Guid id);
}