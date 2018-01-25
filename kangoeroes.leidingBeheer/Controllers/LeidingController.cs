using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Filters;
using kangoeroes.core.Models;
using kangoeroes.core.Models.Responses;
using kangoeroes.leidingBeheer.Auth;
using kangoeroes.leidingBeheer.Models.AuthViewModels;
using kangoeroes.leidingBeheer.Models.ViewModels.Leiding;
using kangoeroes.leidingBeheer.Network;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Http;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestClient = RestEase.RestClient;

namespace kangoeroes.leidingBeheer.Controllers
{
  [Route("/api/[controller]")]
  [ApiValidationFilter]
  public class LeidingController : Controller
  {
    private readonly ILeidingRepository _leidingRepository;
    private readonly ITakRepository _takRepository;
    private readonly IMapper _mapper;
    private readonly Auth0Helper _auth0Helper;
    private readonly IConfiguration _configuration;

    public LeidingController(ILeidingRepository leidingRepository, ITakRepository takRepository, IMapper mapper,
      Auth0Helper auth0Helper, IConfiguration configuration)
    {
      _leidingRepository = leidingRepository;
      _takRepository = takRepository;
      _mapper = mapper;
      this._auth0Helper = auth0Helper;
      _configuration = configuration;
    }

    /// <summary>
    /// Geeft alle leiding terug
    /// </summary>
    /// <returns></returns>
    [HttpGet] //GET /api/leiding
    public IActionResult Index()
    {
      var leiding = _leidingRepository.GetAll();

      var viewModels = _mapper.Map<IEnumerable<BasicLeidingViewModel>>(leiding);
      return Ok(new ApiOkResponse(viewModels));

    }

    [HttpGet] //GET /api/leiding/id
    [Route("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
      var leiding = _leidingRepository.FindById(id);

      var model = _mapper.Map<BasicLeidingViewModel>(leiding);

      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Leiding met id {id} werd niet gevonden"));
      }

      return Ok(new ApiOkResponse(model));
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
      return CreatedAtRoute(leiding.Id, new ApiOkResponse(model));
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
      return Ok(new ApiOkResponse(model));
    }

    [Route("{leidingId}/changeTak")]
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

    [Route("{leidingId}/createUser")]
    [HttpPost]
    public IActionResult CreateUser([FromRoute] int leidingId)
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

      //  var token = await _auth0Helper.GetTokenAsync();
      var url = _configuration["Auth0:domain"];
      var clientId = _configuration["Auth0:ni_client_id"];
      var clientSecret = _configuration["Auth0:ni_client_secret"];
      var audience = _configuration["Auth0:audience"];

      var keyValues = new Dictionary<string, string>
      {
        {"grant_type", "client_credentials"},
        {"client_id", clientId},
        {"client_secret", clientSecret},
        {"audience", audience}
      };

  var client = new HttpClient();
      var fullDomain = url + "/oauth/token";
      HttpContent content = new FormUrlEncodedContent(keyValues);
   // var result = await  client.PostAsync(fullDomain,content).ConfigureAwait(continueOnCapturedContext:false);
      var result = Task.Run(() => client.PostAsync(fullDomain,content)).Result;
      return Ok(result);
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
