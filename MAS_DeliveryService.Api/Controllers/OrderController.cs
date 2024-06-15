using Microsoft.AspNetCore.Mvc;
using MAS_DeliveryService.Api.Domain.Orders;
using MAS_DeliveryService.Api.Domain.Orders.DTOs;

namespace MAS_DeliveryService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet("pending")]
    public async Task<IActionResult> GetPendingOrders()
    {
        var orders = await _orderRepository.GetPendingOrders();
        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> PostOrder(OrderPostRequest request)
    {
        // if (request.ItemIds.Count == 0) return BadRequest("Order must contain at least 1 item");
        var order = new Order(request.Sender, request.Destination, request.ClientId);
        await _orderRepository.CreateOrder(order, request.ItemIds);
        return Created();
    }
}