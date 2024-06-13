using MAS_DeliveryService.Api.Domain.OrderItems;
using Microsoft.AspNetCore.Mvc;
using MAS_DeliveryService.Api.Domain.Orders;
using MAS_DeliveryService.Api.Domain.Orders.DTOs;

namespace MAS_DeliveryService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderController(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
    {
        _orderRepository = orderRepository;
        _orderItemRepository = orderItemRepository;
    }

    [HttpGet("pending")]
    public async Task<IActionResult> GetPendingOrders()
    {
        var orders = await _orderRepository.GetPendingOrders();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        if (!await _orderRepository.OrderExists(id)) return NotFound();
        var order = await _orderRepository.ReadOrder(id);
        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> PostOrder(OrderPostRequest request)
    {
        var order = new Order()
        {
            Id = Guid.NewGuid(),
            Destination = request.Destination,
            Sender = request.Sender,
            ClientId = request.ClientId,
        };
        var orderItems = request.ItemIds.Select(guid => new OrderItem()
        {
            Id = Guid.NewGuid(),
            ItemId = guid,
            OrderId = order.Id
        }).ToList();
        await _orderRepository.CreateOrder(order);
        orderItems.ForEach(oi => _orderItemRepository.CreateOrderItem(oi));
        return CreatedAtAction(nameof(GetOrder), order.Id.ToString());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        if (!await _orderRepository.OrderExists(id)) return NotFound();
        var order = await _orderRepository.ReadOrder(id);
        await _orderRepository.DeleteOrder(order);
        return Ok();
    }
}