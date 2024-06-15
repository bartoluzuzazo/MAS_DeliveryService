using MAS_DeliveryService.Api.Domain.Clients;
using Microsoft.AspNetCore.Mvc;

namespace MAS_DeliveryService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientRepository _clientRepository;

    public ClientController(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    [HttpPost]
    public async Task<IActionResult> PostClient()
    {
        await _clientRepository.AddClient("Imie", "Nazw", "12", "aaa");
        return Created();
    }
}