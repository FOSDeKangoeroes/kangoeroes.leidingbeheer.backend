using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Models.Exceptions;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using kangoeroes.leidingBeheer.Services;
using kangoeroes.leidingBeheer.Services.PoefServices.Interfaces;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.DrankType;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.leidingBeheer.Controllers.PoefControllers
{
  /// <summary>
  /// Controller voor de endpoints die te maken hebben met dranktypes
  /// </summary>
  public class DrankTypeController : BaseController
  {
    private readonly IDrankTypeService _drankTypeService;
    private readonly IMapper _mapper;
    private readonly IPaginationMetaDataService _paginationMetaDataService;

    /// <summary>
    /// Maakt een nieuwe instantie aan van de controller met geïnjecteerde dependencies.
    /// </summary>
    /// <param name="drankTypeService">Service om dranktypes te manipuleren.</param>
    /// <param name="mapper">Service verantwoordelijk om entiteiten te mappen naar viewmodels.</param>
    /// <param name="paginationMetaDataService">Service verantwoordelijk om paginatie data toe te voegen aan een response.</param>
    public DrankTypeController(IDrankTypeService drankTypeService, IMapper mapper, IPaginationMetaDataService paginationMetaDataService)
    {
      _drankTypeService = drankTypeService;
      _mapper = mapper;
      _paginationMetaDataService = paginationMetaDataService;
    }



    /// <summary>
    /// Endpoint die alle dranktypes teruggeeft, rekening houdend met de gegeven parameters.
    /// </summary>
    /// <param name="resourceParameters">Parameters voor het pagineren, filteren en sorteren van de data.</param>
    /// <returns>Een gepagineerde lijst van modellen die alle dranktypes voorstellen.</returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<BasicDrankTypeViewModel>), 200)]
    public IActionResult GetAllTypes([FromQuery] ResourceParameters resourceParameters)
    {
      var types = _drankTypeService.GetAll(resourceParameters);

      var model = _mapper.Map<IEnumerable<BasicDrankTypeViewModel>>(types);

      _paginationMetaDataService.AddMetaDataToResponse(Response, types);

      return Ok(model);



    }


    [HttpGet("{drankTypeId}")]
    [ProducesResponseType(typeof(BasicDrankTypeViewModel), 200)]
    [ProducesResponseType(typeof(string), 404)]
    public async Task<IActionResult> GetTypeById([FromRoute] int drankTypeId)
    {
      try
      {
        var drankType = await _drankTypeService.GetDrankTypeById(drankTypeId);

        var model = _mapper.Map<BasicDrankTypeViewModel>(drankType);

        return Ok(model);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
    }
  }
}
