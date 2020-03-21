using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.DTOs.Adjective;
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
  public class AdjectiefController : BaseController
  {
    private readonly IAdjectiefService _adjectiefService;
    private readonly IMapper _mapper;
    private readonly IPaginationMetaDataService _paginationMetaDataService;

    public AdjectiefController(IAdjectiefService adjectiefService, IMapper mapper, IPaginationMetaDataService paginationMetaDataService)
    {
      _adjectiefService = adjectiefService;
      _mapper = mapper;
      _paginationMetaDataService = paginationMetaDataService;
    }

    // GET
    [HttpGet]
    public IActionResult GetAll([FromQuery] ResourceParameters resourceParameters)
    {

      var adjectieven = _adjectiefService.FindAll(resourceParameters);

      _paginationMetaDataService.AddMetaDataToResponse(Response, adjectieven);

      var model = _mapper.Map<IEnumerable<BasicAdjectiveDTO>>(adjectieven);


      return Ok(model);
    }

    [HttpGet("{id}", Name = "GetAdjectiefById")]
    public async Task<IActionResult> FindById([FromRoute] int id)
    {

        var adjectief = await _adjectiefService.FindByIdAsync(id);
        return Ok(adjectief);

    }

    [HttpPost]
    public async Task<IActionResult> AddAdjectief([FromBody] CreateAdjectiveDTO viewModel)
    {

        var newAdjectief = await _adjectiefService.AddAdjectief(viewModel);

        return CreatedAtRoute("GetAdjectiefById", new {id = newAdjectief.Id}, newAdjectief);

    }

    [HttpPut("{adjectiefId}")]
    public async Task<IActionResult> UpdateAdjectief([FromRoute] int adjectiefId,
      [FromBody] UpdateAdjectiveDTO viewModel)
    {

        var updatedAdjectief = await _adjectiefService.UpdateAdjectief(adjectiefId, viewModel);

        return Ok(updatedAdjectief);

    }
  }
}
