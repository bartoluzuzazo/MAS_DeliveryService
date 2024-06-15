using MAS_DeliveryService.Api.Domain.Clients;
using MAS_DeliveryService.Api.Domain.Items;
using MAS_DeliveryService.Api.Domain.Items.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MAS_DeliveryService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemRepository _itemRepository;

    public ItemController(IItemRepository itemRepository, IClientRepository clientRepository)
    {
        _itemRepository = itemRepository;
    }

    [HttpPost]
    public async Task<IActionResult> PostItem(ItemCreateRequest request)
    {
        var item = new Item()
        {
            Name = request.Name,
            Weight = request.Weight
        };
        await _itemRepository.CreateItem(item);
        return Created();
    }
}