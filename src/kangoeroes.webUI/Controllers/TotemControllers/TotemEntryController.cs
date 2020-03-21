using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.DTOs.TotemEntry;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.webUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.webUI.Controllers.TotemControllers
{
  [Authorize(Roles = "opperhoofd" )]
  public class TotemEntryController : BaseController
  {
    private readonly IMapper _mapper;
    private readonly ITotemEntryService _totemEntryService;
    private readonly IPaginationMetaDataService _paginationMetaDataService;

    public TotemEntryController(ITotemEntryService totemEntryService, IMapper mapper, IPaginationMetaDataService paginationMetaDataService)
    {
      _totemEntryService = totemEntryService;
      _mapper = mapper;
      _paginationMetaDataService = paginationMetaDataService;
    }

    [HttpGet]
    public IActionResult GetAll(ResourceParameters resourceParameters)
    {
      var totemEntries = _totemEntryService.FindAll(resourceParameters);

      _paginationMetaDataService.AddMetaDataToResponse(Response, totemEntries);

      var model = _mapper.Map<IEnumerable<BasicTotemEntryDTO>>(totemEntries);

      return Ok(model);
    }

    [HttpGet("{id}", Name = "GetEntryById")]
    public async Task<IActionResult> FindById([FromRoute] int id)
    {

        var entry = await _totemEntryService.FindByIdAsync(id);
        return Ok(entry);

    }


    [HttpPost]
    public async Task<IActionResult> AddEntry([FromBody] CreateTotemEntryDTO viewmodel)
    {

        var newEntry = await _totemEntryService.AddEntryAsync(viewmodel);

        return CreatedAtRoute("GetEntryById", new {id = newEntry.Id}, newEntry);

    }

    [HttpPost("{totemEntryId}/parent/{voorouderEntryId}")]
    public async Task<IActionResult> AddVoorouder(int totemEntryId, int voorouderEntryId)
    {

        var model = await _totemEntryService.AddVoorOuderAsync(totemEntryId, voorouderEntryId);
        return Ok(model);

    }

    [HttpPut("{totemEntryId}")]
    public async Task<IActionResult> UpdateEntry([FromRoute] int totemEntryId,
      [FromBody] UpdateTotemEntryDTO dto)
    {

        var model = await _totemEntryService.UpdateEntry(totemEntryId, dto);
        return Ok(model);

    }

    [HttpGet("{totemEntryId}/descendants")]
    public IActionResult GetVoorouders([FromRoute] int totemEntryId)
    {
      try
      {
        var descendants = _totemEntryService.GetDescendants(totemEntryId);
        return Ok(descendants);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
    }

    [HttpGet("tree")]
    public IActionResult GetFamilyTree()
    {
      var tree = _totemEntryService.GetFamilyTree();
      return Ok(tree);
    }
  }
}
