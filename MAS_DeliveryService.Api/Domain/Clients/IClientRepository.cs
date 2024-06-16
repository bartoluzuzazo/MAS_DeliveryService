namespace MAS_DeliveryService.Api.Domain.Clients;

public interface IClientRepository
{
    /// <summary>
    /// Metoda pozwalająca na zapis nowego klienta do bazy danych.
    /// W celu zachowania spójności dziedziczenia "overlapping" metoda
    /// tworzy nowe obiekty oraz asocjację między nimi. 
    /// </summary>
    /// <param name="fname">Imię klienta</param>
    /// <param name="lname">Nazwisko klienta</param>
    /// <param name="num">Numer telefonu klienta</param>
    /// <param name="email">Adres email klienta</param>
    public Task AddClient(string fname, string lname, string num, string email);
}