using System.Collections.Generic;
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
  }
}
