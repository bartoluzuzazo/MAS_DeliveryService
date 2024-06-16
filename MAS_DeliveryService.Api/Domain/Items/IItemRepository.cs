namespace MAS_DeliveryService.Api.Domain.Items;

public interface IItemRepository
{
    /// <summary>
    /// Metoda pozwalająca na zapis nowego przedmiotu do bazy danych. 
    /// </summary>
    /// <param name="item">Nowy przedmiot</param>
    /// <returns></returns>
    public Task AddItem(Item item);
    public Task<List<Item>> GetItems();
    public Task<Item> GetItem(Guid id);
    public Task<bool> ItemExists(Guid id);
}