
using System;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Models;
using kangoeroes.leidingBeheer.Filters;
using kangoeroes.leidingBeheer.Models.Responses;
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
      //[Route("")]
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
      [Route("{id}")]
      public IActionResult GetTakById([FromRoute] int id)
      {

        var tak = _takRepository.FindById(id);
        if (tak == null)
        {
          return NotFound(new ApiResponse(404, $"Tak met id {id} werd niet gevonden"));
        }

        return Ok(new ApiOkResponse(tak));
      }

      [HttpPost]
      public IActionResult AddTak([FromBody] AddTakViewModel viewmodel)
      {

        var tak = MapToTak(viewmodel);
        _takRepository.Add(tak);
        _takRepository.SaveChanges();
        return CreatedAtRoute(tak.Id, new ApiOkResponse(tak));
      }

      private Tak MapToTak(AddTakViewModel viewModel)
      {
        Tak tak = new Tak()
        {
          Naam = viewModel.Naam,
          Volgorde =  viewModel.Volgorde
        };
        return tak;
      }
    }
}
