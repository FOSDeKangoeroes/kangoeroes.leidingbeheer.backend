
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Filters;
using kangoeroes.core.Models;
using kangoeroes.core.Models.Responses;
using kangoeroes.leidingBeheer.Models.ViewModels.Tak;
using Microsoft.AspNetCore.Mvc;


namespace kangoeroes.leidingBeheer.Controllers
{
    [Route("/api/[controller]")]
    [ApiValidationFilter]
    public class TakController: Controller
    {
      private readonly ITakRepository _takRepository;

      public TakController(ITakRepository takRepository)
      {
        _takRepository = takRepository;
      }

      /// <summary>
      /// Geeft alle takken terug
      /// </summary>
      /// <returns>Lijst van alle takken</returns>
      [HttpGet] //GET api/tak
      public IActionResult Index()
      {
        var takken = _takRepository.GetAll();
        return Ok(new ApiOkResponse(takken));
      }

      /// <summary>
      /// Geef het tak object terug van de tak met opgegeven id.
      /// Wanneer de gegeven id niet overeenkomt met een bestaande tak, dan wordt een 404-error teruggegeven.
      /// </summary>
      /// <param name="id">Unieke identifier van de tak</param>
      /// <returns>1 tak object</returns>
      [Route("{id}")] //GET api/tak/{id}
      [HttpGet]
      public IActionResult GetTakById([FromRoute] int id)
      {

        var tak = _takRepository.FindById(id);
        if (tak == null)
        {
          return NotFound(new ApiResponse(404, $"Tak met id {id} werd niet gevonden"));
        }

        return Ok(new ApiOkResponse(tak));
      }

      /// <summary>
      /// Tak toevoegen met een naam en een volgorde. Id wordt toegekend door de database. Leiding wordt toegevoegd via de LeidingController
      /// </summary>
      /// <param name="viewmodel"></param>
      /// <returns></returns>
      [HttpPost] //POST /api/tak
      public IActionResult AddTak([FromBody] AddTakViewModel viewmodel)
      {
        Tak tak = new Tak();
        tak = MapToTak(tak,viewmodel);
        _takRepository.Add(tak);
        _takRepository.SaveChanges();
        return CreatedAtRoute(tak.Id, new ApiOkResponse(tak));
      }

      /// <summary>
      /// Updaten van de naam en/of volgorde van een tak. De meegegeven id bepaalt de te updaten tak. Leiding speelt geen rol.
      /// </summary>
      /// <param name="viewmodel"></param>
      /// <returns></returns>
      [HttpPut] //PUT /api/tak
      public IActionResult UpdateTak([FromBody] UpdateTakViewModel viewmodel)
      {
        Tak tak = _takRepository.FindById(viewmodel.Id);

        if (tak == null)
        {
          return NotFound(new ApiResponse(404, $"Tak met id {viewmodel.Id} werd niet gevonden"));
        }

        tak = MapToTak(tak,viewmodel);
        _takRepository.Update(tak);
        _takRepository.SaveChanges();
        return Ok(new ApiOkResponse(tak));
      }

      /// <summary>
      /// Verwijderen van tak met de gegeven id in de route
      /// </summary>
      /// <param name="id">Id van tak die verwijderd moet worden</param>
      /// <returns></returns>
      [Route("{id}")] //DELETE /api/tak/id
      [HttpDelete]
      public IActionResult DeleteTak([FromRoute] int id)
      {
        var tak = _takRepository.FindById(id);
        if (tak == null)
        {
          return NotFound(new ApiResponse(404, $"Tak met id {id} werd niet gevonden"));
        }

        if (tak.Leiding.Count > 0)
        {
          ModelState.AddModelError("LeidingAanwezig","De tak bevat nog leiding.");
          return BadRequest(new ApiBadRequestResponse(ModelState));
        }

        _takRepository.Delete(tak);
        _takRepository.SaveChanges();
        return Ok(tak);
      }

     /// <summary>
     /// Mappen van een tak viewmodel uit een request naar een tak entiteit
     /// </summary>
     /// <param name="tak">Entiteit</param>
     /// <param name="viewModel">Viewmodel</param>
     /// <returns></returns>
      private Tak MapToTak(Tak tak,AddTakViewModel viewModel)
      {
        tak.Naam = viewModel.Naam;
        tak.Volgorde = viewModel.Volgorde;
        return tak;
      }
    }
}
