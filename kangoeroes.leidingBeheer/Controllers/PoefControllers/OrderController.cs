using System;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Models.Exceptions;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using kangoeroes.leidingBeheer.Services.PoefServices.Interfaces;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Order;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Orderline;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.leidingBeheer.Controllers.PoefControllers
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
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderViewModel viewModel)
    {
      try
      {
        var newOrder = await _orderService.CreateOrder(viewModel);

        var model = _mapper.Map<BasicOrderViewModel>(newOrder);
        return Ok(model);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
    }

    [HttpPut("{orderId}")]
    public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderViewModel viewModel, [FromRoute] int orderId)
    {
      try
      {
        var updatedOrder = await _orderService.UpdateOrder(viewModel, orderId);

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
      [FromBody] UpdateOrderlineViewModel viewModel,
      [FromRoute] int orderId,
      [FromRoute] int orderlineId)
    {
      try
      {
        var updatedOrderline = await _orderService.UpdateOrderline(viewModel, orderId, orderlineId);

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



   //order via id ophalen
  }
}
