﻿using System.Collections.Generic;
using AutoMapper;
using kangoeroes.core.DTOs.Tab.Orderline;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models.Poef;
using kangoeroes.webUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.webUI.Controllers.PoefControllers
{
  [Authorize(Roles = "financieel_verantwoordelijke" )]
  public class OrderlineController: BaseController
  {
    private readonly IOrderlineService _orderlineService;
    private readonly IMapper _mapper;
    private readonly IPaginationMetaDataService _paginationMetaDataService;

    public OrderlineController(IOrderlineService orderlineService, IMapper mapper, IPaginationMetaDataService paginationMetaDataService)
    {
      _orderlineService = orderlineService;
      _mapper = mapper;
      _paginationMetaDataService = paginationMetaDataService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BasicOrderlineDTO>> GetAllOrderlines(
      [FromQuery] OrderlineResourceParameters parameters)
    {
      var result = _orderlineService.GetAllOrderlines(parameters);
      var mapped = _mapper.Map<IEnumerable<BasicOrderlineDTO>>(result);
      _paginationMetaDataService.AddMetaDataToResponse(Response, result);

      return Ok(mapped);
    }

    [HttpGet]
    [Route("summary")]
    public ActionResult<IEnumerable<PersonOrderlineSummary>> GetOrderlineSummary([FromQuery] OrderlineResourceParameters parameters)
    {
      var result = _orderlineService.GetOrderlineSummary(parameters);

      return Ok(result);
    }
  }
}
