using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.leidingBeheer.Controllers
{
  [Route("/api/[controller]")]
  public class LeidingController : Controller
  {
    [Route("Index")]
    public string Index()
    {
      return "Hallo";

    }
  }
}
