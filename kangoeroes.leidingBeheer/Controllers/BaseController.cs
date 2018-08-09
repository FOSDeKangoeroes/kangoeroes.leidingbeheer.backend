using kangoeroes.leidingBeheer.Filters;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.leidingBeheer.Controllers
{
  [Route("/api/[controller]")]
  [ModelStateIsValid]
  public abstract class BaseController : ControllerBase
  {
  }
}
