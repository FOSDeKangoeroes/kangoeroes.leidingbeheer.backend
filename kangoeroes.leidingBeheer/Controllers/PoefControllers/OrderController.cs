using System;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.leidingBeheer.Services.PoefServices.Interfaces;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Order;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.leidingBeheer.Controllers.PoefControllers
{

  public class OrderController: BaseController
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
  }
}
