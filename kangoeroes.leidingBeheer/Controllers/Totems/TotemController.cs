using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Models.Exceptions;
using kangoeroes.leidingBeheer.Filters;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Models.ViewModels.Totem;
using kangoeroes.leidingBeheer.Services.TotemServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer.Controllers.Totems
{

  public class TotemController : BaseController
  {
    private readonly ITotemService _totemService;
    private readonly IMapper _mapper;

    public TotemController(ITotemService totemService, IMapper mapper)
    {
      _totemService = totemService;
      _mapper = mapper;

    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] ResourceParameters resourceParameters)
    {

      var result = _totemService.FindAll(resourceParameters);
      var paginationMetaData = new
      {
        totalCount = result.TotalCount,
        pageSize = result.PageSize,
        currentPage = result.CurrentPage,
        totalPages = result.TotalPages,

      };



      var model = _mapper.Map<IEnumerable<BasicTotemViewModel>>(result);
      Response.Headers.Add("X-Pagination",JsonConvert.SerializeObject(paginationMetaData));
      return Ok(model);
    }

    [HttpGet("{id}", Name = "GetTotemById")]
    public async Task<IActionResult> FindById([FromRoute] int id)
    {
      try
      {
        var totem = await _totemService.FindByIdAsync(id);
        return Ok(totem);
      }
      catch (EntityNotFoundException ex)
      {
        return NotFound(ex.Message);
      }



    }

    [HttpPost]
    public async Task<IActionResult> AddTotem([FromBody] AddTotemViewModel viewModel)
    {
      try
      {
        var newTotem = await _totemService.AddTotemAsync(viewModel);
        return CreatedAtRoute("GetTotemById", new {id = newTotem.Id}, newTotem);
      }
      catch (EntityExistsException ex)
      {
        return BadRequest(ex.Message);
      }
      catch (EntityNotFoundException ex)
      {
        return NotFound(ex.Message);
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTotem([FromBody] UpdateTotemViewModel viewModel, [FromRoute] int id)
    {
      try
      {
        var updatedTotem = await _totemService.UpdateTotemAsync(viewModel, id);

        return Ok(updatedTotem);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
      catch (EntityExistsException e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}
