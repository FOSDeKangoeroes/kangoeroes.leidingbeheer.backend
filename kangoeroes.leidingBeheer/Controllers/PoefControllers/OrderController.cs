using System;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Models.Exceptions;
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


    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderViewModel viewModel)
    {
      try
      {
        var newOrder = await _orderService.CreateOrder(viewModel);

        var model = _mapper.Map<BasicOrderViewModel>(newOrder);
        return Ok(model);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
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

    [HttpPut("{orderId}/orderline/{orderlineId}")]
    public async Task<IActionResult> UpdateOrderline([FromBody] UpdateOrderlineViewModel viewModel, [FromRoute] int orderId, [FromRoute] int orderlineId )
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
  }
}
