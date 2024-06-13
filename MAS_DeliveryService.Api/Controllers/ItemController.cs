using MAS_DeliveryService.Api.Domain.Items;
using MAS_DeliveryService.Api.Domain.Items.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MAS_DeliveryService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemRepository _itemRepository;

    public ItemController(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetItems()
    {
        Console.WriteLine(Directory.GetCurrentDirectory());
        var item = await _itemRepository.ReadItems();
        return Ok(item);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItem(Guid id)
    {
        if (!await _itemRepository.ItemExists(id)) return NotFound();
        var item = await _itemRepository.ReadItem(id);
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> PostItem(ItemCreateRequest request)
    {
        var item = new Item()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Weight = request.Weight
        };
        await _itemRepository.CreateItem(item);
        return CreatedAtAction(nameof(GetItem), item.Id.ToString());
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteItem(Guid id)
    {
        if (!await _itemRepository.ItemExists(id)) return NotFound();
        var item = await _itemRepository.ReadItem(id);
        await _itemRepository.DeleteItem(item);
        return Ok();
    }
}