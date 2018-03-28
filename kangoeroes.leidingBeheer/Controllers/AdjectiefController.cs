using System;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models.Exceptions;
using kangoeroes.leidingBeheer.Models.ViewModels.Adjectief;
using kangoeroes.leidingBeheer.Services.TotemServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer.Controllers
{
  [Route("api/[controller]")]
  public class AdjectiefController : ControllerBase
  {

    private readonly IAdjectiefService _adjectiefService;

    public AdjectiefController(IAdjectiefService adjectiefService)
    {
      _adjectiefService = adjectiefService;
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
        totalPages = adjectieven.TotalPages,

      };

      Response.Headers.Add("X-Pagination",JsonConvert.SerializeObject(paginationMetaData));
      return Ok(adjectieven);
    }

    [HttpGet("{id}",Name = "GetAdjectiefById")]
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
  }
}
