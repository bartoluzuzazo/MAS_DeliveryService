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
    private readonly IPackageItemRepository _packageItemRepository;

    public PackageController(IPackageRepository packageRepository, IPackageItemRepository packageItemRepository)
    {
        _packageRepository = packageRepository;
        _packageItemRepository = packageItemRepository;
    }


    [HttpPost]
    public async Task<IActionResult> PostPackages(PackagePostRequestWrapper request)
    {
        var newPackages = new List<Package>();
        var newPackageItems = new List<PackageItem>();
        request.Packages.ForEach(p =>
        {
            var package = new Package()
            {
                Id = Guid.NewGuid(),
                SerialNumber = p.Serialnumber,
                Comment = p.Comment,
                SentInId = request.OrderId,
                DeliveredInId = null,
            };
            newPackages.Add(package);
            p.ItemIds.ForEach(id =>
            {
                var pi = new PackageItem()
                {
                    Id = Guid.NewGuid(),
                    ItemId = id,
                    PackageId = package.Id
                };
                newPackageItems.Add(pi);
            });
        });

        newPackages.ForEach(AddNewPackages);

        newPackageItems.ForEach(AddNewPackageItems);
        
        return Created();

        async void AddNewPackageItems(PackageItem pi) => await _packageItemRepository.AddPackageItem(pi);
        async void AddNewPackages(Package p) => await _packageRepository.AddPackage(p);
    }
}