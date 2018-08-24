using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Models.Exceptions;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using kangoeroes.leidingBeheer.Services.TotemServices.Interfaces;
using kangoeroes.leidingBeheer.ViewModels.AdjectiefViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer.Controllers.TotemControllers
{
  public class AdjectiefController : BaseController
  {
    private readonly IAdjectiefService _adjectiefService;
    private readonly IMapper _mapper;

    public AdjectiefController(IAdjectiefService adjectiefService, IMapper mapper)
    {
      _adjectiefService = adjectiefService;
      _mapper = mapper;
    }

    // GET
    [HttpGet]
    public IActionResult GetAll([FromQuery] ResourceParameters resourceParameters)
    {
      var adjectieven = _adjectiefService.FindAll(resourceParameters);

      var paginationMetaData = new
      {
        totalCount = adjectieven.TotalCount,
        pageSize = adjectieven.PageSize,
        currentPage = adjectieven.CurrentPage,
        totalPages = adjectieven.TotalPages
      };

      var model = _mapper.Map<IEnumerable<BasicAdjectiefViewModel>>(adjectieven);

      Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetaData));
      return Ok(model);
    }

    [HttpGet("{id}", Name = "GetAdjectiefById")]
    public async Task<IActionResult> FindById([FromRoute] int id)
    {
      try
      {
        var adjectief = await _adjectiefService.FindByIdAsync(id);
        return Ok(adjectief);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> AddAdjectief([FromBody] AddAdjectiefViewModel viewModel)
    {
      try
      {
        var newAdjectief = await _adjectiefService.AddAdjectief(viewModel);

        return CreatedAtRoute("GetAdjectiefById", new {id = newAdjectief.Id}, newAdjectief);
      }
      catch (EntityExistsException e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{adjectiefId}")]
    public async Task<IActionResult> UpdateAdjectief([FromRoute] int adjectiefId,
      [FromBody] UpdateAdjectiefViewModel viewModel)
    {
      try
      {
        var updatedAdjectief = await _adjectiefService.UpdateAdjectief(adjectiefId, viewModel);

        return Ok(updatedAdjectief);
      }
      catch (EntityNotFoundException ex)
      {
        return NotFound(ex.Message);
      }
    }
  }
}
