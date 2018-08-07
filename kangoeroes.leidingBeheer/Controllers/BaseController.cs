using kangoeroes.leidingBeheer.Filters;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.leidingBeheer.Controllers
{
  [Route("/api/[controller]")]
  [ApiValidationFilter]
  public abstract class BaseController: ControllerBase
  {

  }
}
