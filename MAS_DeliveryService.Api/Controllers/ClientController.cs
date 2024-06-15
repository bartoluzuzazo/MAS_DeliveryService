using MAS_DeliveryService.Api.Domain.Clients;
using MAS_DeliveryService.Api.Domain.Clients.DTOs;
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
    public async Task<IActionResult> PostClient(ClientPostRequest request)
    {
        await _clientRepository.AddClient(request.FirstName, request.LastName, request.Number, request.Email);
        return Created();
    }
}