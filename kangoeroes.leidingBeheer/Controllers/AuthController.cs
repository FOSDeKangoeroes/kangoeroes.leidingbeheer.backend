using kangoeroes.leidingBeheer.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.leidingBeheer.Controllers
{
  [Route("/api/[controller]")]
  public class AuthController : Controller
  {
    private IAuth0Service _auth0Service;

    public AuthController(IAuth0Service auth0Service)
    {
      _auth0Service = auth0Service;
    }
    // GET
    [HttpGet("roles")]
    public IActionResult Roles()
    {
      return Ok(_auth0Service.GetAllRoles());

    }
  }
}
