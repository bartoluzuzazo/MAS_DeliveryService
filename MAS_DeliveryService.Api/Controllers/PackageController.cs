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


    [HttpPost]
    public async Task<IActionResult> PostPackages(PackagePostRequestWrapper request)
    {
        var newPackages = new List<(Package, List<Guid>)>();
        var newPackageItems = new List<PackageItem>();
        request.Packages.ForEach(p =>
        {
            var package = new Package()
                {
                    SerialNumber = p.Serialnumber,
                    Comment = p.Comment,
                    SentInId = request.OrderId,
                    DeliveredInId = request.OrderId,
                
            };
            newPackages.Add((package, p.ItemIds));
        });

        newPackages.ForEach(p =>
        {
            p.Item2.ForEach(id =>
            {
                var packageItem = new PackageItem()
                {
                    PackageId = p.Item1.Id,
                    ItemId = id
                };
                newPackageItems.Add(packageItem);
            });
        });

        try
        {
            await _packageRepository.AddPackages(newPackages.Select(p => p.Item1), newPackageItems);
        }
        catch (EmptyCollectionException e)
        {
            return BadRequest(e.Message);
        }

        return Created();
    }
}