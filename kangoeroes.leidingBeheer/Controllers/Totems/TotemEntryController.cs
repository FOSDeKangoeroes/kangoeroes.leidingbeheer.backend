using System.Collections.Generic;
using AutoMapper;
using kangoeroes.core.Helpers;
using kangoeroes.leidingBeheer.Models.ViewModels.TotemEntry;
using kangoeroes.leidingBeheer.Services.TotemServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer.Controllers.Totems
{
  [Route("api/[controller]")]
  public class TotemEntryController : ControllerBase
  {
    private ITotemEntryService _totemEntryService;
    private IMapper _mapper;

    public TotemEntryController(ITotemEntryService totemEntryService, IMapper mapper)
    {
      _totemEntryService = totemEntryService;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll(ResourceParameters resourceParameters)
    {
      var totemEntries = _totemEntryService.FindAll(resourceParameters);

      var paginationMetaData = new
      {
        totalCount = totemEntries.TotalCount,
        pageSize = totemEntries.PageSize,
        currentPage = totemEntries.CurrentPage,
        totalPages = totemEntries.TotalPages,

      };

      var model = _mapper.Map<IEnumerable<BasicTotemEntryViewModel>>(totemEntries);

      Response.Headers.Add("X-Pagination",JsonConvert.SerializeObject(paginationMetaData));
      return Ok(model);
    }
  }
}
