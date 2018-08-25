using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using AutoMapper;
using kangoeroes.core.Models;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using kangoeroes.leidingBeheer.Services;
using kangoeroes.leidingBeheer.Services.Auth;
using kangoeroes.leidingBeheer.ViewModels.LeidingViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer.Controllers
{
  //[Authorize(Roles = "financieel_verantwoordelijke")]
  public class LeidingController : BaseController
  {
    private readonly ILeidingRepository _leidingRepository;
    private readonly IMapper _mapper;
    private readonly ITakRepository _takRepository;
    private readonly IPaginationMetaDataService _paginationMetaDataService;


    public LeidingController(
      ILeidingRepository leidingRepository,
      ITakRepository takRepository,
      IMapper mapper,
      IConfiguration configuration,
      IPaginationMetaDataService paginationMetaDataService)
    {
      _leidingRepository = leidingRepository;
      _takRepository = takRepository;
      _mapper = mapper;
      _paginationMetaDataService = paginationMetaDataService;
    }

    /// <summary>
    ///   Geeft alle leiding terug
    /// </summary>
    /// <returns></returns>
    [HttpGet] //GET /api/leiding
    public IActionResult Index([FromQuery] LeidingResourceParameters resourceParameters)
    {
      var leiding = _leidingRepository.FindAll(resourceParameters);

      _paginationMetaDataService.AddMetaDataToResponse(Response, leiding);

      var viewModels = _mapper.Map<IEnumerable<BasicLeidingViewModel>>(leiding);
      return Ok(viewModels);
    }

    [HttpGet("{id}", Name = "GetLeidingById")] //GET /api/leiding/id
    // [Authorize(Roles = "financieel_verantwoordelijke")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var leiding = await _leidingRepository.FindByIdAsync(id);

      var model = _mapper.Map<BasicLeidingViewModel>(leiding);

      if (leiding == null) return NotFound($"Leiding met id {id} werd niet gevonden");

      return Ok(model);
    }

    [HttpPost] //POST api/leiding
    public async Task<IActionResult> AddLeiding([FromBody] AddLeidingViewModel viewmodel)
    {
      Tak tak = null;
      if (viewmodel.TakId != 0)
      {
        tak = await _takRepository.FindByIdAsync(viewmodel.TakId);
        if (tak == null) return NotFound($"Opgegeven tak met id {viewmodel.TakId} werd niet gevonden");
      }


      var leiding = new Leiding();
      leiding = MapToLeiding(leiding, tak, viewmodel);
      await _leidingRepository.AddAsync(leiding);
      await _leidingRepository.SaveChangesAsync();
      var model = _mapper.Map<BasicLeidingViewModel>(leiding);
      return CreatedAtRoute(leiding.Id, model);
    }

    [HttpPut] //PUT api/leiding
    [Route("{id}")]
    public async Task<IActionResult> UpdateLeiding([FromRoute] int id, [FromBody] UpdateLeidingViewModel viewmodel)
    {
      var leiding = await _leidingRepository.FindByIdAsync(id);

      if (leiding == null) return NotFound($"Opgegeven leiding met id {id} werd niet gevonden");

      leiding = _mapper.Map(viewmodel, leiding);
      leiding.DatumGestopt = viewmodel.DatumGestopt.ToLocalTime();
      leiding.LeidingSinds = viewmodel.LeidingSinds.ToLocalTime();
      // await _leidingRepository.UpdateAsync(leiding);
      await _leidingRepository.SaveChangesAsync();
      var model = _mapper.Map<BasicLeidingViewModel>(leiding);
      return Ok(model);
    }

    [Route("{leidingId}/tak")]
    [HttpPut]
    public async Task<IActionResult> ChangeTak([FromRoute] int leidingId, [FromBody] ChangeTakViewModel viewModel)
    {
      var leiding = await _leidingRepository.FindByIdAsync(leidingId);
      if (leiding == null) return NotFound($"Opgegeven leiding met id {leidingId} werd niet gevonden");

      var newTak = await _takRepository.FindByIdAsync(viewModel.NewTakId);
      if (newTak == null) return NotFound($"Opgegeven tak met id {viewModel.NewTakId} werd niet gevonden");


      leiding.Tak = newTak;
      //  _leidingRepository.Update(leiding);
      await _leidingRepository.SaveChangesAsync();
      var model = _mapper.Map<BasicLeidingViewModel>(leiding);

      return Ok(model);
    }

    [Route("{leidingId}/user")]
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromRoute] int leidingId, [FromServices] IAuth0Service auth0Service)
    {
      var leiding = await _leidingRepository.FindByIdAsync(leidingId);

      if (leiding == null) return NotFound($"Opgegeven leiding met id {leidingId} werd niet gevonden");

      if (leiding.Email == null)
      {
        ModelState.AddModelError("NoEmail",
          "De gebruiker heeft geen emailadres. Kan geen gebruiker maken zonder email");
        return BadRequest(ModelStateFormatter.FormatErrors(ModelState));
      }


      try
      {
        var userModel = await auth0Service.MakeNewUserFor(leiding.Email);
        leiding.Auth0Id = userModel.UserId;
        await _leidingRepository.SaveChangesAsync();
        var model = _mapper.Map<BasicLeidingViewModel>(leiding);
        return CreatedAtRoute("GetLeidingById", new {id = model.Id}, model);
      }
      catch (ApiException ex)
      {
        ModelState.AddModelError("auth0Exception", ex.Message);
        return BadRequest(ModelStateFormatter.FormatErrors(ModelState));
      }
    }

    [HttpGet("{leidingId}/roles")]
    public async Task<IActionResult> GetRolesForUser([FromRoute] int leidingId,
      [FromServices] Auth0Service auth0Service)
    {
      var leiding = await _leidingRepository.FindByIdAsync(leidingId);


      if (leiding == null) return NotFound($"Opgegeven leiding met id {leidingId} werd niet gevonden");

      if (leiding.Email == null)
      {
        ModelState.AddModelError("NoEmail",
          "Deze leiding heeft geen emailadres. Deze gebruiker kan geen account hebben.");
        return BadRequest(ModelStateFormatter.FormatErrors(ModelState));
      }

      if (string.IsNullOrEmpty(leiding.Auth0Id))
      {
        ModelState.AddModelError("NoAccount",
          "Deze leiding heeft nog geen account. Maak eerst een account aan.");
        return BadRequest(ModelStateFormatter.FormatErrors(ModelState));
      }

      return Ok(auth0Service.GetAllRolesForUser(leiding.Auth0Id));
    }

    [HttpPatch("{leidingId}/roles/{roleId}")]
    public async Task<IActionResult> AddRoleToUser([FromRoute] int leidingId, [FromRoute] string roleId,
      [FromServices] Auth0Service auth0Service)
    {
      var leiding = await _leidingRepository.FindByIdAsync(leidingId);


      if (leiding == null) return NotFound($"Opgegeven leiding met id {leidingId} werd niet gevonden");

      if (leiding.Email == null)
      {
        ModelState.AddModelError("NoEmail",
          "Deze leiding heeft geen emailadres. Deze gebruiker kan geen account hebben.");
        return BadRequest(ModelStateFormatter.FormatErrors(ModelState));
      }

      if (string.IsNullOrEmpty(leiding.Auth0Id))
      {
        ModelState.AddModelError("NoAccount",
          "Deze leiding heeft nog geen account. Maak eerst een account aan.");
        return BadRequest(ModelStateFormatter.FormatErrors(ModelState));
      }

      var success = auth0Service.AddRoleToUser(leiding.Auth0Id, roleId);

      return Ok(success);
    }

    [HttpDelete("{leidingId}/roles/{roleId}")]
    public async Task<IActionResult> RemoveRoleFromUser([FromRoute] int leidingId, [FromRoute] string roleId,
      [FromServices] Auth0Service auth0Service)
    {
      var leiding = await _leidingRepository.FindByIdAsync(leidingId);

      if (leiding == null) return NotFound($"Opgegeven leiding met id {leidingId} werd niet gevonden");

      if (leiding.Email == null)
      {
        ModelState.AddModelError("NoEmail",
          "Deze leiding heeft geen emailadres. Deze gebruiker kan geen account hebben.");
        return BadRequest(ModelStateFormatter.FormatErrors(ModelState));
      }

      if (string.IsNullOrEmpty(leiding.Auth0Id))
      {
        ModelState.AddModelError("NoAccount",
          "Deze leiding heeft nog geen account. Maak eerst een account aan.");
        return BadRequest(ModelStateFormatter.FormatErrors(ModelState));
      }

      var success = auth0Service.RemoveRoleFromUser(leiding.Auth0Id, roleId);

      return Ok(success);
    }

    private static Leiding MapToLeiding(Leiding leiding, Tak tak, AddLeidingViewModel viewModel)
    {
      leiding.Auth0Id = viewModel.Auth0Id;
      leiding.DatumGestopt = viewModel.DatumGestopt.ToLocalTime();
      if (viewModel.Email != null && viewModel.Email.Trim() != "") leiding.Email = viewModel.Email;

      leiding.LeidingSinds = viewModel.LeidingSinds.ToLocalTime();
      leiding.Naam = viewModel.Naam;
      leiding.Voornaam = viewModel.Voornaam;
      leiding.Tak = tak;

      return leiding;
    }
  }
}
