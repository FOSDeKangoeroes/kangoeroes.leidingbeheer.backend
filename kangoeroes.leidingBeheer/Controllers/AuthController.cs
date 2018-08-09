using kangoeroes.leidingBeheer.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.leidingBeheer.Controllers
{
  public class AuthController : BaseController
  {
    private readonly IAuth0Service _auth0Service;

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
