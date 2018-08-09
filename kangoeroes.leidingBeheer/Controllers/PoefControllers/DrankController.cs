using System.Collections.Generic;
using AutoMapper;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Services.PoefServices.Interfaces;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer.Controllers.PoefControllers
{

  public class DrankController : BaseController
  {
    private readonly IDrankService _drankService;
    private readonly IMapper _mapper;


    public DrankController(IDrankService drankService, IMapper mapper)
    {
      _drankService = drankService;
      _mapper = mapper;
    }

    [HttpGet("")]
    public IActionResult GetAll([FromQuery] ResourceParameters resourceParameters)
    {
      var dranken = _drankService.GetAll(resourceParameters);

      var paginationMetaData = new
      {
        totalCount = dranken.TotalCount,
        pageSize = dranken.PageSize,
        currentPage = dranken.CurrentPage,
        totalPages = dranken.TotalPages,
      };

      Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetaData));

      var model = _mapper.Map<IEnumerable<BasicDrankViewModel>>(dranken);
      return Ok(model);
    }
  }
}
