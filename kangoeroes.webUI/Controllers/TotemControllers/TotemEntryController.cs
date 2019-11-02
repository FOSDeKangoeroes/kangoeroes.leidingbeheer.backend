using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.webUI.DTOs.TotemEntry;
using kangoeroes.webUI.Interfaces;
using kangoeroes.webUI.Services;
using kangoeroes.webUI.Services.TotemServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kangoeroes.webUI.Controllers.TotemControllers
{
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

      var model = _mapper.Map<IEnumerable<BasicTotemEntryViewModel>>(totemEntries);

      return Ok(model);
    }

    [HttpGet("{id}", Name = "GetEntryById")]
    public async Task<IActionResult> FindById([FromRoute] int id)
    {
      try
      {
        var entry = await _totemEntryService.FindByIdAsync(id);
        return Ok(entry);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
    }


    [HttpPost]
    public async Task<IActionResult> AddEntry([FromBody] AddEntryExistingLeiding viewmodel)
    {
      try
      {
        var newEntry = await _totemEntryService.AddEntryAsync(viewmodel);

        return CreatedAtRoute("GetEntryById", new {id = newEntry.Id}, newEntry);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
      catch (EntityExistsException e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost("{totemEntryId}/parent/{voorouderEntryId}")]
    public async Task<IActionResult> AddVoorouder(int totemEntryId, int voorouderEntryId)
    {
      try
      {
        var model = await _totemEntryService.AddVoorOuderAsync(totemEntryId, voorouderEntryId);
        return Ok(model);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
    }

    [HttpPut("{totemEntryId}")]
    public async Task<IActionResult> UpdateEntry([FromRoute] int totemEntryId,
      [FromBody] UpdateTotemEntryViewModel viewModel)
    {
      try
      {
        var model = await _totemEntryService.UpdateEntry(totemEntryId, viewModel);
        return Ok(model);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
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
