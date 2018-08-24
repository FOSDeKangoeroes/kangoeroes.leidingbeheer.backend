using System.Collections.Generic;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.DrankType;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.leidingBeheer.Controllers.PoefControllers
{
  public class DrankTypeController : BaseController
  {
    // GET
    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<BasicDrankTypeViewModel>), 200)]
    public IActionResult GetAllTypes()
    {
      return Ok("Hello");

    }
  }
}
