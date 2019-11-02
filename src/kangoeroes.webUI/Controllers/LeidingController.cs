using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.DTOs.Leader;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models;
using kangoeroes.webUI.Interfaces;
using kangoeroes.webUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace kangoeroes.webUI.Controllers
{
  //[Authorize(Roles = "financieel_verantwoordelijke")]
  public class LeidingController : BaseController
  {
    private readonly ILeidingRepository _leidingRepository;
    private readonly IMapper _mapper;
    private readonly ITakRepository _takRepository;
    private readonly IPaginationMetaDataService _paginationMetaDataService;
    private readonly ILeaderService _leaderService;


    public LeidingController(
      ILeidingRepository leidingRepository,
      ITakRepository takRepository,
      IMapper mapper,
      IConfiguration configuration,
      IPaginationMetaDataService paginationMetaDataService,
      ILeaderService leaderService)
    {
      _leidingRepository = leidingRepository;
      _takRepository = takRepository;
      _mapper = mapper;
      _paginationMetaDataService = paginationMetaDataService;
      _leaderService = leaderService;
    }

    /// <summary>
    ///   Geeft alle leiding terug
    /// </summary>
    /// <returns></returns>
    [HttpGet] //GET /api/leiding
    public IActionResult Index([FromQuery] LeidingResourceParameters resourceParameters)
    {
      var leiding = _leidingRepository.FindAll(resourceParameters);

      _paginationMetaDataService.AddMetaDataToResponse(Response, leiding);

      var viewModels = _mapper.Map<IEnumerable<BasicLeaderDTO>>(leiding);
      return Ok(viewModels);
    }

    [HttpGet("{id}", Name = "GetLeidingById")] //GET /api/leiding/id
    // [Authorize(Roles = "financieel_verantwoordelijke")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var leiding = await _leidingRepository.FindByIdAsync(id);

      var model = _mapper.Map<BasicLeaderDTO>(leiding);

      if (leiding == null) return NotFound($"Leiding met id {id} werd niet gevonden");

      return Ok(model);
    }

    [HttpPost] //POST api/leiding
    public async Task<IActionResult> AddLeiding([FromBody] CreateLeaderDTO dto)
    {

      var newLeaderDTO = await _leaderService.CreateLeader(dto);
      return CreatedAtRoute(newLeaderDTO.Id, newLeaderDTO);

    }

    [HttpPut] //PUT api/leiding
    [Route("{id}")]
    public async Task<IActionResult> UpdateLeiding([FromRoute] int id, [FromBody] UpdateLeaderDTO viewmodel)
    {
      var leiding = await _leidingRepository.FindByIdAsync(id);

      if (leiding == null) return NotFound($"Opgegeven leiding met id {id} werd niet gevonden");

      leiding = _mapper.Map(viewmodel, leiding);
      leiding.DatumGestopt = viewmodel.DatumGestopt.ToLocalTime();
      leiding.LeidingSinds = viewmodel.LeidingSinds.ToLocalTime();
      await _leidingRepository.SaveChangesAsync();
      var model = _mapper.Map<BasicLeaderDTO>(leiding);
      return Ok(model);
    }

    [Route("{leidingId}/tak")]
    [HttpPut]
    public async Task<IActionResult> ChangeTak([FromRoute] int leidingId, [FromBody] UpdateSectionDTO viewModel)
    {
      var leiding = await _leidingRepository.FindByIdAsync(leidingId);
      if (leiding == null) return NotFound($"Opgegeven leiding met id {leidingId} werd niet gevonden");

      var newTak = await _takRepository.FindByIdAsync(viewModel.NewSectionId);
      if (newTak == null) return NotFound($"Opgegeven tak met id {viewModel.NewSectionId} werd niet gevonden");


      leiding.Tak = newTak;
      await _leidingRepository.SaveChangesAsync();
      var model = _mapper.Map<BasicLeaderDTO>(leiding);

      return Ok(model);
    }

  }
}
