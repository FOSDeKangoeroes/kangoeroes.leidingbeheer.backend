using System.Threading.Tasks;
using kangoeroes.core.Filters;
using kangoeroes.core.Models.Exceptions;
using kangoeroes.leidingBeheer.Models.ViewModels.Totem;
using kangoeroes.leidingBeheer.Services.TotemServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.leidingBeheer.Controllers.Totems
{
  [Route("api/[controller]")]
  [ApiValidationFilter]
  public class TotemController : ControllerBase
  {
    private readonly ITotemService _totemService;

    public TotemController(ITotemService totemService)
    {
      _totemService = totemService;

    }

    [HttpGet]
    public IActionResult GetAll()
    {

      var model = _totemService.FindAll();

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
