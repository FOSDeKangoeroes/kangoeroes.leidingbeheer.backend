using kangoeroes.leidingBeheer.Filters;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.leidingBeheer.Controllers
{
  [Route("/api/[controller]")]
  [ModelStateIsValid]
  [Produces("application/json")]
  public abstract class BaseController : ControllerBase
  {
  }
}
