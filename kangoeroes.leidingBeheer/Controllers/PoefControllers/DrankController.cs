using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using kangoeroes.leidingBeheer.Services.PoefServices.Interfaces;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer.Controllers.PoefControllers
{
  /// <summary>
  /// Controller met alle endpoints voor het beheren van dranken.
  /// </summary>
  public class DrankController : BaseController
  {
    private readonly IDrankService _drankService;
    private readonly IMapper _mapper;


    /// <summary>
    /// Maakt een nieuwe instantie aan van de DrankController
    /// </summary>
    /// <param name="drankService">Service verantwoordelijk voor het uitvoeren van businesslogice ivm dranken</param>
    /// <param name="mapper">Instantie van automapper om entiteiten teruggegeven door de service om te zetten naar viewmodels.</param>
    public DrankController(IDrankService drankService, IMapper mapper)
    {
      _drankService = drankService;
      _mapper = mapper;
    }

    /// <summary>
    /// Geeft een OK (200) met een viewmodel van alle dranken, gepagineerd en gefilterd volgens de meegegeven query parameters
    /// </summary>
    /// <param name="resourceParameters"> Query parameters voor het pagineren en filteren van dranken</param>
    /// <returns></returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<BasicDrankViewModel>),200)]
    public IActionResult GetAll([FromQuery] ResourceParameters resourceParameters)
    {
      var dranken = _drankService.GetAll(resourceParameters);

      var paginationMetaData = new
      {
        totalCount = dranken.TotalCount,
        pageSize = dranken.PageSize,
        currentPage = dranken.CurrentPage,
        totalPages = dranken.TotalPages
      };

      Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetaData));

      var model = _mapper.Map<IEnumerable<BasicDrankViewModel>>(dranken);
      return Ok(model);
    }

    /// <summary>
    /// Endpoint voor het ophalen van een specifieke drank aan de hand van de unieke sleutel.
    /// </summary>
    /// <param name="drankId">Unieke sleutel van de gevraagde drank.</param>
    /// <returns> OK (200) - BasicDrankViewModel van de gevraagde drank.</returns>
    /// <returns>Not Found (404) - Foutboodschap, drank werd niet gevonden.</returns>
    [HttpGet("{drankId}", Name = "FindDrankById")]
    [ProducesResponseType(typeof(BasicDrankViewModel),200)]
    [ProducesResponseType(typeof(string), 400)]
    public async  Task<IActionResult> FindByIdAsync([FromRoute] int drankId)
    {
      var drank = await _drankService.GetDrankById(drankId);

      if (drank == null)
      {
        return NotFound($"Drank met id {drankId} werd niet gevonden.");
      }

      var model = _mapper.Map<BasicDrankViewModel>(drank);

      return Ok(model);
    }
  }
}
