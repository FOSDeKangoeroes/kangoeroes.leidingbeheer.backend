using System.Collections.Generic;
using AutoMapper;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using kangoeroes.leidingBeheer.Services;
using kangoeroes.leidingBeheer.Services.PoefServices.Interfaces;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.DrankType;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.leidingBeheer.Controllers.PoefControllers
{
  public class DrankTypeController : BaseController
  {
    private readonly IDrankTypeService _drankTypeService;
    private readonly IMapper _mapper;
    private readonly IPaginationMetaDataService _paginationMetaDataService;

    public DrankTypeController(IDrankTypeService drankTypeService, IMapper mapper, IPaginationMetaDataService paginationMetaDataService)
    {
      _drankTypeService = drankTypeService;
      _mapper = mapper;
      _paginationMetaDataService = paginationMetaDataService;
    }



    // GET
    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<BasicDrankTypeViewModel>), 200)]
    public IActionResult GetAllTypes([FromQuery] ResourceParameters resourceParameters)
    {
      var types = _drankTypeService.GetAll(resourceParameters);

      var model = _mapper.Map<IEnumerable<BasicDrankTypeViewModel>>(types);

      _paginationMetaDataService.AddMetaDataToResponse(Response, types);

      return Ok(model);



    }
  }
}
