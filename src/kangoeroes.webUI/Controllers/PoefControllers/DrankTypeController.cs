using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.DTOs.Tab.Drink;
using kangoeroes.core.DTOs.Tab.DrinkType;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models.Poef;
using kangoeroes.webUI.Interfaces;
using kangoeroes.webUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.webUI.Controllers.PoefControllers
{
  /// <summary>
  /// Controller voor de endpoints die te maken hebben met dranktypes
  /// </summary>
  public class DrankTypeController : BaseController
  {
    private readonly IDrankTypeService _drankTypeService;
    private readonly IMapper _mapper;
    private readonly IPaginationMetaDataService _paginationMetaDataService;

    private readonly IDrankService _drankService;

    /// <summary>
    /// Maakt een nieuwe instantie aan van de controller met geïnjecteerde dependencies.
    /// </summary>
    /// <param name="drankTypeService">Service om dranktypes te manipuleren.</param>
    /// <param name="mapper">Service verantwoordelijk om entiteiten te mappen naar viewmodels.</param>
    /// <param name="paginationMetaDataService">Service verantwoordelijk om paginatie data toe te voegen aan een response.</param>
    public DrankTypeController(
      IDrankTypeService drankTypeService,
      IMapper mapper,
      IPaginationMetaDataService paginationMetaDataService,
      IDrankService drankService)
    {
      _drankTypeService = drankTypeService;
      _mapper = mapper;
      _paginationMetaDataService = paginationMetaDataService;
      _drankService = drankService;
    }


    /// <summary>
    /// Endpoint die alle dranktypes teruggeeft, rekening houdend met de gegeven parameters.
    /// </summary>
    /// <param name="resourceParameters">Parameters voor het pagineren, filteren en sorteren van de data.</param>
    /// <returns>Een gepagineerde lijst van modellen die alle dranktypes voorstellen.</returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<BasicDrinkTypeDTO>), 200)]
    public IActionResult GetAllTypes([FromQuery] ResourceParameters resourceParameters)
    {
      var types = _drankTypeService.GetAll(resourceParameters);

      var model = _mapper.Map<IEnumerable<BasicDrinkTypeDTO>>(types);

      _paginationMetaDataService.AddMetaDataToResponse(Response, types);

      return Ok(model);
    }


    /// <summary>
    /// Endpoint die een dranktype teruggeeft aan de hand van de gegeven unieke sleutel.
    /// </summary>
    /// <param name="drankTypeId">Unieke sleutel van het type.</param>
    /// <returns>Een model van het gevonden dranktype. Indien er geen dranktype overeenkomt met de sleutel, wordt een 404 teruggegeven met een foutboodschap.</returns>
    [HttpGet("{drankTypeId}", Name = "GetTypeById")]
    [ProducesResponseType(typeof(BasicDrinkTypeDTO), 200)]
    [ProducesResponseType(typeof(string), 404)]
    public async Task<IActionResult> GetTypeById([FromRoute] int drankTypeId)
    {
      var drankType = await _drankTypeService.GetDrankTypeById(drankTypeId);

      var model = _mapper.Map<BasicDrinkTypeDTO>(drankType);

      return Ok(model);
    }

    /// <summary>
    /// Endpoint voor het aanmaken van een nieuw dranktype
    /// </summary>
    /// <param name="dto">Viewmodel met data voor het aanmaken van een dranktype</param>
    /// <returns>Model van het nieuw aangemaakte type</returns>
    [HttpPost("")]
    [ProducesResponseType(typeof(BasicDrinkTypeDTO), 201)]
    [ProducesResponseType(typeof(string), 400)]
    public async Task<IActionResult> CreateType([FromBody] CreateDrinkTypeDTO dto)
    {
      var newType = await _drankTypeService.CreateDrankType(dto);

      var model = _mapper.Map<BasicDrinkTypeDTO>(newType);

      return CreatedAtRoute("GetTypeById", new {drankTypeId = newType.Id}, model);
    }


    /// <summary>
    /// Endpoint voor het wijzigen van een type. Dit endpoint wijzigt alle velden naar de waarden gegeven in het model.
    /// Een  optioneel veld in het viewmodel wordt dus leeggemaakt indien dit in het viewmodel leeg is.
    /// </summary>
    /// <param name="dto">Model met de nieuwe gegevens van het type</param>
    /// <param name="drankTypeId">Unieke sleutel van het te wijzigen type</param>
    /// <returns>Een model van het gewijzigde type</returns>
    [HttpPut("{drankTypeId}")]
    [ProducesResponseType(typeof(BasicDrinkTypeDTO), 200)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(typeof(string), 400)]
    public async Task<IActionResult> UpdateType([FromBody] UpdateDrinkTypeDTO dto, [FromRoute] int drankTypeId)
    {
      var updatedType = await _drankTypeService.UpdateDrankType(dto, drankTypeId);

      var model = _mapper.Map<BasicDrinkTypeDTO>(updatedType);

      return Ok(model);
    }

    /// <summary>
    /// Verwijdert een dranktype. Dit kan enkel uitgevoerd worden wanneer een type geen dranken meer aan zich toegekend heeft.
    /// </summary>
    /// <param name="drankTypeId">Unieke sleutel van het te verwijderen type.</param>
    /// <returns>Een lege body wanneer het type succesvol verwijdert werd.</returns>
    [HttpDelete("{drankTypeId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(typeof(string), 400)]
    public async Task<IActionResult> DeleteType([FromRoute] int drankTypeId)
    {
      await _drankTypeService.DeleteDrankType(drankTypeId);

      return Ok();
    }

    [HttpGet("{drankTypeId}/dranken")]
    public async Task<IActionResult> GetDrankForType([FromRoute] int drankTypeId,
      [FromQuery] ResourceParameters resourceParameters)
    {
      var dranken = await _drankService.GetDrankenForType(drankTypeId, resourceParameters);

      var model = _mapper.Map<IEnumerable<BasicDrinkDTO>>(dranken);

      _paginationMetaDataService.AddMetaDataToResponse(Response, dranken);

      return Ok(model);
    }
  }
}
