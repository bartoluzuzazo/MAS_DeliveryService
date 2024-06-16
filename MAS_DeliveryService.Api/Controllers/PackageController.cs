using MAS_DeliveryService.Api.Domain.Exceptions;
using MAS_DeliveryService.Api.Domain.PackageItems;
using MAS_DeliveryService.Api.Domain.Packages;
using MAS_DeliveryService.Api.Domain.Packages.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MAS_DeliveryService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PackageController : ControllerBase
{
    private readonly IPackageRepository _packageRepository;

    public PackageController(IPackageRepository packageRepository)
    {
        _packageRepository = packageRepository;
    }

    /// <summary>
    /// Końcówka używana przez przypadek użycia "Rejestracja paczek".
    /// Pozwala na zapisanie w bazie danych informacji na temat paczek,
    /// które zostały przypisane do danego zamówienia.
    /// Jednocześnie tworzy asocjacje z zapakowanymi w nie przedmiotami.
    /// </summary>
    /// <param name="request">
    /// Żądanie utworzenia listy paczek zawierające identyfikator zamówienia
    /// oraz listę danych nowych paczek.
    /// Dane nowej paczki zawierają jej numer seryjny, opcjonalny komentarz i listę
    /// zapakowanych do niej przedmiotów. 
    /// </param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> PostPackages(PackagePostRequestWrapper request)
    {
        var newPackages = new List<(Package, List<Guid>)>();
        var newPackageItems = new List<PackageItem>();
        request.Packages.ForEach(p =>
        {
            var package = new Package(p.Serialnumber, p.Comment, request.OrderId);
            newPackages.Add((package, p.ItemIds));
        });

        newPackages.ForEach(p =>
        {
            p.Item2.ForEach(id =>
            {
                var packageItem = new PackageItem(id, p.Item1.Id);
                newPackageItems.Add(packageItem);
            });
        });

        try
        {
            await _packageRepository.AddPackages(newPackages.Select(p => p.Item1).ToList(), newPackageItems);
        }
        catch (EmptyCollectionException e)
        {
            return BadRequest(e.Message);
        }
        catch (TooHeavyException e)
        {
            return BadRequest(e.Message);
        }

        return Created();
    }
}