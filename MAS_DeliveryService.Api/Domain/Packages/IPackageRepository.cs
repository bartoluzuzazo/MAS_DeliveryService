using MAS_DeliveryService.Api.Domain.PackageItems;

namespace MAS_DeliveryService.Api.Domain.Packages;

public interface IPackageRepository
{
    /// <summary>
    /// Metoda umożliwiająca zapisanie dodanych paczek w bazie danych.
    /// Waliduje, czy paczki zawierają tylko zamówione przedmioty, oraz czy nie są puste.
    /// </summary>
    /// <param name="packages">Lista nowych paczek</param>
    /// <param name="packageItems">Lista asocjacji pomiędzy paczkami a przedmiotami</param>
    /// <exception cref="EmptyCollectionException">Wyjątek podnoszony w wypadku próby utworzenia pustej paczki</exception>
    /// <exception cref="Exception">Wyjątek podnoszony w wypadku próby dodania niezamówionego przedmiotu do paczki</exception>
    public Task AddPackages(List<Package> packages, List<PackageItem> packageItems);
    
    public Task<List<Package>> GetPackages();

}