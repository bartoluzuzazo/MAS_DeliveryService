using MAS_DeliveryService.Api.Domain.Items.DTOs;
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

    /// <summary>
    /// Końcówka używana przez przypadek użycia "Rejestracja paczek".
    /// Umożliwia pozyskanie listy zamówień, których aktualny status to "Pendning".
    /// </summary>
    /// <returns></returns>
    [HttpGet("pending")]
    public async Task<IActionResult> GetPendingOrders()
    {
        var orders = await _orderRepository.GetPendingOrders();
        var dtos = orders.Select(o => new OrderGetResponse()
        {
            Id = o.Id,
            Sender = o.Sender,
            Destination = o.Destination,
            Items = o.OrderItems.Select(oi => new ItemGetResponse()
            {
                Id = oi.Item.Id,
                Name = oi.Item.Name,
                Weight = oi.Item.Weight
            }).ToList(),
            ClientFirstName = o.Client.Person.FirstName,
            ClientLastName = o.Client.Person.LastName
        }).ToList();
        return Ok(dtos);
    }

    /// <summary>
    /// Dodatkowa końcówka, która umożliwia dodanie zamówienia. 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> PostOrder(OrderPostRequest request)
    {
        var order = new Order(request.Sender, request.Destination, request.ClientId);
        await _orderRepository.CreateOrder(order, request.ItemIds);
        return Created();
    }
}