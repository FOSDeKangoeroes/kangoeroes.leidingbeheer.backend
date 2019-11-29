using AutoMapper;
using kangoeroes.core.Models.Responses;
using kangoeroes.webUI.Services;
using kangoeroes.webUI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.webUI.Controllers
{
  /// <summary>
  /// Basiscontroller waar alle controllers in dit project van erven. Gedaan om te vermijden dat alle annotaties hieronder per controller herhaald moeten worden.
  /// </summary>
  [Route("/api/[controller]")] // Alle endpoints volgen deze url structuur: {basisurl}/api/{controllernaam}
  [ModelStateIsValid] //Bij endpoints in controllers die van deze controller erven wordt gekeken of de modelstate valid is.

  // Ale endpoints in controllers die van deze controller erven produceren JSON.
  // Wordt hier expliciet aangegeven zodat dit correct wordt weergegeven in de Swagger documentatie
  [Produces("application/json")]

  [ProducesResponseType(typeof(ApiServerErrorResponse), 500)] //In principe kunnen alle endpoints een 500 error teruggeven.
  public abstract class BaseController : ControllerBase
  {
  }
}
