using System;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.DTOs.Tab.Order;
using kangoeroes.core.DTOs.Tab.Orderline;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.webUI.Controllers.PoefControllers
{
  public class OrderController : BaseController
  {
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;


    public OrderController(IOrderService orderService, IMapper mapper)
    {
      _orderService = orderService;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllOrders([FromQuery] OrderResourceParameters resourceParameters)
    {
      var orders = _orderService.GetAllOrders(resourceParameters);

      return Ok(orders);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderById([FromRoute] int orderId)
    {
      try
      {
        var order = await _orderService.GetOrderById(orderId);

        return Ok(order);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }

    }



    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO dto)
    {
      try
      {
        var newOrder = await _orderService.CreateOrder(dto);

        var model = _mapper.Map<BasicOrderDTO>(newOrder);
        return Ok(model);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
    }

    [HttpPut("{orderId}")]
    public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDTO dto, [FromRoute] int orderId)
    {
      try
      {
        var updatedOrder = await _orderService.UpdateOrder(dto, orderId);

        return Ok(updatedOrder);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
    }

    [HttpDelete("{orderId}")]
    public async Task<IActionResult> DeleteOrder([FromRoute] int orderId)
    {
      try
      {
        var orderToDelete = await _orderService.DeleteOrder(orderId);

        return Ok(orderToDelete);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
    }

    [HttpPut("{orderId}/orderline/{orderlineId}")]
    public async Task<IActionResult> UpdateOrderline(
      [FromBody] UpdateOrderlineDTO dto,
      [FromRoute] int orderId,
      [FromRoute] int orderlineId)
    {
      try
      {
        var updatedOrderline = await _orderService.UpdateOrderline(dto, orderId, orderlineId);

        return Ok(updatedOrderline);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
    }

    [HttpDelete("{orderId}/orderline/{orderlineId}")]
    public async Task<IActionResult> DeleteOrderline(int orderId, int orderlineId)
    {
      try
      {
        var deletedOrderline = await _orderService.DeleteOrderline(orderId, orderlineId);

        return Ok(deletedOrderline);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
    }

  }
}
