using MAS_DeliveryService.Api.Domain.Static;
using Microsoft.AspNetCore.Mvc;

namespace MAS_DeliveryService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaticController : ControllerBase
{
    private readonly IStaticRepository _staticRepository;

    public StaticController(IStaticRepository staticRepository)
    {
        _staticRepository = staticRepository;
    }

    [HttpGet("MaxWeight")]
    public async Task<IActionResult> GetMaxWeight()
    {
        return Ok(await _staticRepository.GetMaxWeight());
    }

}