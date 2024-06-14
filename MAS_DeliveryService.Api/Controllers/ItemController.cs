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
    private readonly IClientRepository _clientRepository;

    public ItemController(IItemRepository itemRepository, IClientRepository clientRepository)
    {
        _itemRepository = itemRepository;
        _clientRepository = clientRepository;
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
            Name = request.Name,
            Weight = request.Weight
        };
        await _itemRepository.CreateItem(item);
        return CreatedAtAction(nameof(GetItem), item.Id.ToString());
    }
    
    [HttpPost("cl")]
    public async Task<IActionResult> PostClient()
    {
        await _clientRepository.AddClient("Imie", "Nazw", "111222333", "aa@a.pl");
        return Created();
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