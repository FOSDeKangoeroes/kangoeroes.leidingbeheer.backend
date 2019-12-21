using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.DTOs.Tab.Period;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models.Poef;
using kangoeroes.webUI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.webUI.Controllers.PoefControllers
{
  public class PeriodController: BaseController
  {
    private readonly IPeriodService _periodService;
    private readonly IMapper _mapper;
    private readonly IPaginationMetaDataService _paginationMetaDataService;

    public PeriodController(IPeriodService periodService, IMapper mapper, IPaginationMetaDataService paginationMetaDataService)
    {
      _periodService = periodService;
      _mapper = mapper;
      _paginationMetaDataService = paginationMetaDataService;
    }
    [HttpGet]
    public ActionResult<IEnumerable<BasicPeriodDTO>> GetAll([FromQuery] ResourceParameters resourceParameters)
    {
      var periods = _periodService.GetAllPeriods(resourceParameters);
      var mapped = _mapper.Map<IEnumerable<BasicPeriodDTO>>(periods);
      _paginationMetaDataService.AddMetaDataToResponse(Response,periods);

      return Ok(mapped);
    }

    [HttpGet("{periodId}", Name = "FindPeriodById")]
    public async Task<ActionResult<BasicPeriodDTO>> GetPeriodById([FromRoute] int periodId)
    {
      var period = await _periodService.FindPeriodById(periodId);
      var mapped = _mapper.Map<BasicPeriodDTO>(period);
      return Ok(mapped);
    }

    [HttpPost]
    public async Task<ActionResult<BasicPeriodDTO>> CreatePeriod([FromBody] CreatePeriodDTO dto)
    {
      var newPeriod = await _periodService.CreatePeriod(dto);
      var mapped = _mapper.Map<BasicPeriodDTO>(newPeriod);

      return CreatedAtRoute("FindPeriodById", new {periodId = newPeriod.Id}, mapped);
    }
  }
}
