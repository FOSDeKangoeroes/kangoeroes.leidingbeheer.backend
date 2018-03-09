
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using AutoMapper;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Filters;
using kangoeroes.core.Models;
using kangoeroes.core.Models.Responses;
using kangoeroes.leidingBeheer.Models.ViewModels.Leiding;
using kangoeroes.leidingBeheer.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using RestSharp;


namespace kangoeroes.leidingBeheer.Controllers
{
  [Route("/api/[controller]")]
  [ApiValidationFilter]
  public class LeidingController : Controller
  {
    private readonly ILeidingRepository _leidingRepository;
    private readonly ITakRepository _takRepository;
    private readonly IMapper _mapper;
    private readonly IAuth0Service _auth0Service;
    private readonly IConfiguration _configuration;

    public LeidingController(ILeidingRepository leidingRepository, ITakRepository takRepository, IMapper mapper,
      IAuth0Service auth0Service, IConfiguration configuration)
    {
      _leidingRepository = leidingRepository;
      _takRepository = takRepository;
      _mapper = mapper;
       _auth0Service = auth0Service;
      _configuration = configuration;
    }

    /// <summary>
    /// Geeft alle leiding terug
    /// </summary>
    /// <returns></returns>
    [HttpGet] //GET /api/leiding
    public IActionResult Index([FromQuery] string sortBy = "naam", [FromQuery] string sortOrder = "", [FromQuery] string query = "", [FromQuery] int tak = 0)
    {

      if (query == null)
      {
        query = "";
      }



      var sortString = sortBy + " " + sortOrder;
      var leiding = _leidingRepository.FindAll(query,sortString,tak);

      var viewModels = _mapper.Map<IEnumerable<BasicLeidingViewModel>>(leiding);
      return Ok(viewModels);

    }

    [HttpGet] //GET /api/leiding/id
    [Route("{id}")]
   // [Authorize(Roles = "financieel_verantwoordelijke")]
    public IActionResult GetById([FromRoute] int id)
    {


      var leiding = _leidingRepository.FindById(id);

      var model = _mapper.Map<BasicLeidingViewModel>(leiding);

      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Leiding met id {id} werd niet gevonden"));
      }

      return Ok(model);
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
      var model = _mapper.Map<BasicLeidingViewModel>(leiding);
      return CreatedAtRoute(leiding.Id, model);
    }

    [HttpPut] //PUT api/leiding
    [Route("{id}")]
    public IActionResult UpdateLeiding([FromRoute] int id, [FromBody] UpdateLeidingViewModel viewmodel)
    {
      var leiding = _leidingRepository.FindById(id);

      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven leiding met id {id} werd niet gevonden"));
      }

      leiding = _mapper.Map(viewmodel, leiding);
      _leidingRepository.Update(leiding);
      _leidingRepository.SaveChanges();
      var model = _mapper.Map<BasicLeidingViewModel>(leiding);
      return Ok(model);
    }

    [Route("{leidingId}/tak")]
    [HttpPut]
    public IActionResult ChangeTak([FromRoute] int leidingId, [FromBody] ChangeTakViewModel viewModel)
    {
      var leiding = _leidingRepository.FindById(leidingId);
      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven leiding met id {leidingId} werd niet gevonden"));
      }

      var newTak = _takRepository.FindById(viewModel.NewTakId);
      if (newTak == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven tak met id {viewModel.NewTakId} werd niet gevonden"));

      }


      leiding.Tak = newTak;
      _leidingRepository.Update(leiding);
      _leidingRepository.SaveChanges();
      var model = _mapper.Map<BasicLeidingViewModel>(leiding);

      return Ok(new ApiOkResponse(model));
    }

    [Route("{leidingId}/user")]
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromRoute] int leidingId)
    {
      var leiding = _leidingRepository.FindById(leidingId);

      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven leiding met id {leidingId} werd niet gevonden"));
      }

      if (leiding.Email == null)
      {
        ModelState.AddModelError("NoEmail",
          "De gebruiker heeft geen emailadres. Kan geen gebruiker maken zonder email");
        return BadRequest(new ApiBadRequestResponse(ModelState));
      }



      try
      {
        var userModel = await _auth0Service.MakeNewUserFor(leiding.Email);
      leiding.Auth0Id = userModel.UserId;
      _leidingRepository.SaveChanges();
      var model = _mapper.Map<BasicLeidingViewModel>(leiding);
      return Created(model.Email,new ApiCreatedResponse(model));
      }
      catch (ApiException ex)
      {
        ModelState.AddModelError("auth0Exception",ex.Message);
        return BadRequest(new ApiBadRequestResponse(ModelState));
      }

    }

    [HttpGet("{leidingId}/roles")]
    public IActionResult GetRolesForUser([FromRoute] int leidingId)
    {
      var leiding = _leidingRepository.FindById(leidingId);


      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven leiding met id {leidingId} werd niet gevonden"));
      }

      if (leiding.Email == null)
      {
        ModelState.AddModelError("NoEmail",
          "Deze leiding heeft geen emailadres. Deze gebruiker kan geen account hebben.");
        return BadRequest(new ApiBadRequestResponse(ModelState));
      }

      if (string.IsNullOrEmpty(leiding.Auth0Id))
      {
        ModelState.AddModelError("NoEmail",
          "Deze leiding heeft nog geen account. Maak eerst een account aan.");
        return BadRequest(new ApiBadRequestResponse(ModelState));
      }


      //Alle rollen ophalen, rollen checken van gegeven persoon, mappen


      return Ok(_auth0Service.GetAllRolesForUser(leiding.Auth0Id));
    }

    private static Leiding MapToLeiding(Leiding leiding, Tak tak, AddLeidingViewModel viewModel)
    {
      leiding.Auth0Id = viewModel.Auth0Id;
      leiding.DatumGestopt = viewModel.DatumGestopt;
      if (viewModel.Email != null && viewModel.Email.Trim() != "")
      {
        leiding.Email = viewModel.Email;
      }

      leiding.LeidingSinds = viewModel.LeidingSinds;
      leiding.Naam = viewModel.Naam;
      leiding.Voornaam = viewModel.Voornaam;
      leiding.Tak = tak;

      return leiding;

    }




  }
}
