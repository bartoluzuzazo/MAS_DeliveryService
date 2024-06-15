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

    [HttpPost]
    public async Task<IActionResult> PostOrder(OrderPostRequest request)
    {
        var order = new Order()
        {
            Destination = request.Destination,
            Sender = request.Sender,
            ClientId = request.ClientId,
        };
        
        await _orderRepository.CreateOrder(order);
        
        var orderItems = request.ItemIds.Select(guid => new OrderItem()
        {
            ItemId = guid,
            OrderId = order.Id
        }).ToList();
        
        orderItems.ForEach(oi => _orderItemRepository.CreateOrderItem(oi));
        return Created();
    }
}