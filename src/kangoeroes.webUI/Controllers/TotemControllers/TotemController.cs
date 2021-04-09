﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.DTOs.Animal;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.webUI.Interfaces;
using kangoeroes.webUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kangoeroes.webUI.Controllers.TotemControllers
{
  [Authorize(Roles = "opperhoofd" )]
  public class TotemController : BaseController
  {
    private readonly IMapper _mapper;
    private readonly ITotemService _totemService;
    private readonly IPaginationMetaDataService _paginationMetaDataService;

    public TotemController(ITotemService totemService, IMapper mapper, IPaginationMetaDataService paginationMetaDataService)
    {
      _totemService = totemService;
      _mapper = mapper;
      _paginationMetaDataService = paginationMetaDataService;
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] ResourceParameters resourceParameters)
    {
      var result = _totemService.FindAll(resourceParameters);

      _paginationMetaDataService.AddMetaDataToResponse(Response, result);

      var model = _mapper.Map<IEnumerable<BasicAnimalDTO>>(result);

      return Ok(model);
    }

    [HttpGet("{id}", Name = "GetTotemById")]
    public async Task<IActionResult> FindById([FromRoute] int id)
    {

        var totem = await _totemService.FindByIdAsync(id);
        return Ok(totem);


    }

    [HttpPost]
    public async Task<IActionResult> AddTotem([FromBody] AddAnimalDTO viewModel)
    {

        var newTotem = await _totemService.AddTotemAsync(viewModel);
        return CreatedAtRoute("GetTotemById", new {id = newTotem.Id}, newTotem);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTotem([FromBody] UpdateAnimalDTO viewModel, [FromRoute] int id)
    {

        var updatedTotem = await _totemService.UpdateTotemAsync(viewModel, id);

        return Ok(updatedTotem);

    }
  }
}
