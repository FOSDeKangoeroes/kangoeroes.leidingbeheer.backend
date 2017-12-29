using System;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Filters;
using kangoeroes.core.Models;
using kangoeroes.core.Models.Responses;
using kangoeroes.leidingBeheer.Models.ViewModels.Leiding;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.leidingBeheer.Controllers
{
  [Route("/api/[controller]")]
  [ApiValidationFilter]
  public class LeidingController : Controller
  {
    private readonly ILeidingRepository _leidingRepository;
    private readonly ITakRepository _takRepository;

    public LeidingController(ILeidingRepository leidingRepository, ITakRepository takRepository)
    {
      _leidingRepository = leidingRepository;
      _takRepository = takRepository;
    }
    /// <summary>
    /// Geeft alle leiding terug
    /// </summary>
    /// <returns></returns>
    [HttpGet] //GET /api/leiding
    public IActionResult Index()
    {
      var leiding = _leidingRepository.GetAll();
      return Ok(new ApiOkResponse(leiding));

    }

    [HttpGet] //GET /api/leiding/id
    [Route("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
      var leiding = _leidingRepository.FindById(id);


      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Leiding met id {id} werd niet gevonden"));
      }

      return Ok(new ApiOkResponse(leiding));
    }

    [HttpPost] //POST api/leiding
    public IActionResult AddLeiding([FromBody] AddLeidingViewModel viewmodel)
    {
      var tak = _takRepository.FindById(viewmodel.TakId);
      if (tak == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven tak met id {viewmodel.TakId} werd niet gevonden"));
      }
     Leiding leiding = new Leiding();
      leiding = MapToLeiding(leiding, tak, viewmodel);
      _leidingRepository.Add(leiding);
      _leidingRepository.SaveChanges();
      return CreatedAtRoute(leiding.Id, new ApiOkResponse(leiding));
    }

    [HttpPut] //PUT api/leiding
    public IActionResult UpdateLeiding([FromBody] UpdateLeidingViewModel viewmodel)
    {
      var leiding = _leidingRepository.FindById(viewmodel.Id);

      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven leiding met id {viewmodel.Id} werd niet gevonden"));
      }
      var tak = _takRepository.FindById(viewmodel.TakId);

      if (tak == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven tak met id {viewmodel.TakId} werd niet gevonden"));

      }

      leiding = MapToLeiding(leiding, tak, viewmodel);
      _leidingRepository.Update(leiding);
      _leidingRepository.SaveChanges();

      return Ok(new ApiOkResponse(leiding));
    }

    private static Leiding MapToLeiding(Leiding leiding,Tak tak, AddLeidingViewModel viewModel)
    {
      leiding.Auth0Id = viewModel.Auth0Id;
      leiding.DatumGestopt = viewModel.DatumGestopt;
      leiding.Email = viewModel.Email;
      leiding.LeidingSinds = viewModel.LeidingSinds;
      leiding.Naam = viewModel.Naam;
      leiding.Voornaam = viewModel.Voornaam;
      leiding.Tak = tak;

      return leiding;

    }
  }
}
