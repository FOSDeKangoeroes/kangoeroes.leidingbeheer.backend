using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Models;
using kangoeroes.webUI.DTOs.Leader;
using kangoeroes.webUI.DTOs.TakViewModels;
using kangoeroes.webUI.Helpers;
using kangoeroes.webUI.Interfaces;
using kangoeroes.webUI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kangoeroes.webUI.Controllers
{
  public class TakController : BaseController
  {
    private readonly IMapper _mapper;
    private readonly ITakRepository _takRepository;
    private readonly IPaginationMetaDataService _paginationMetaDataService;

    public TakController(ITakRepository takRepository, IMapper mapper, IPaginationMetaDataService paginationMetaDataService)
    {
      _takRepository = takRepository;
      _mapper = mapper;
      _paginationMetaDataService = paginationMetaDataService;
    }

    /// <summary>
    ///   Geeft alle takken terug
    /// </summary>
    /// <returns>Lijst van alle takken</returns>
    [HttpGet] //GET api/tak
    public IActionResult Index([FromQuery] ResourceParameters resourceParameters)
    {
      var takken = _takRepository.FindAll(resourceParameters);

     _paginationMetaDataService.AddMetaDataToResponse(Response, takken);

      var model = _mapper.Map<IEnumerable<BasicTakViewModel>>(takken);
      return Ok(model);
    }

    /// <summary>
    ///   Geef het tak object terug van de tak met opgegeven id.
    ///   Wanneer de gegeven id niet overeenkomt met een bestaande tak, dan wordt een 404-error teruggegeven.
    /// </summary>
    /// <param name="id">Unieke identifier van de tak</param>
    /// <returns>1 tak object</returns>
    //GET api/tak/{id}
    [HttpGet("{id}", Name = "GetTakById")]
    public async Task<IActionResult> GetTakById([FromRoute] int id)
    {
      var tak = await _takRepository.FindByIdAsync(id);
      if (tak == null) return NotFound($"Tak met id {id} werd niet gevonden");

      var model = _mapper.Map<BasicTakViewModel>(tak);

      return Ok(model);
    }

    /// <summary>
    ///   Tak toevoegen met een naam en een volgorde. Id wordt toegekend door de database. Leiding wordt toegevoegd via de
    ///   LeidingController
    /// </summary>
    /// <param name="viewmodel"></param>
    /// <returns></returns>
    [HttpPost] //POST /api/tak
    public async Task<IActionResult> AddTak([FromBody] AddTakViewModel viewmodel)
    {
      var tak = new Tak
      {
        Naam = viewmodel.Naam,
        Volgorde = viewmodel.Volgorde
      };
      await _takRepository.AddAsync(tak);
      await _takRepository.SaveChangesAsync();
      var model = _mapper.Map<BasicTakViewModel>(tak);
      return CreatedAtRoute("GetTakById", new {id = model.Id}, model);
    }

    /// <summary>
    ///   Updaten van de naam en/of volgorde van een tak. De meegegeven id bepaalt de te updaten tak. Leiding speelt geen rol.
    /// </summary>
    /// <param name="viewmodel"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut] //PUT /api/tak
    [Route("{id}")]
    public async Task<IActionResult> UpdateTak([FromRoute] int id, [FromBody] AddTakViewModel viewmodel)
    {
      var tak = await _takRepository.FindByIdAsync(id);

      if (tak == null) return NotFound($"Tak met id {id} werd niet gevonden");


      tak.Naam = viewmodel.Naam;
      tak.Volgorde = viewmodel.Volgorde;

      // _takRepository.Update(tak);
      await _takRepository.SaveChangesAsync();
      var model = _mapper.Map<BasicTakViewModel>(tak);
      return Ok(model);
    }

    /// <summary>
    ///   Verwijderen van tak met de gegeven id in de route
    /// </summary>
    /// <param name="id">Id van tak die verwijderd moet worden</param>
    /// <returns></returns>
    [Route("{id}")] //DELETE /api/tak/id
    [HttpDelete]
    public async Task<IActionResult> DeleteTak([FromRoute] int id)
    {
      var tak = await _takRepository.FindByIdAsync(id);
      if (tak == null) return NotFound($"Tak met id {id} werd niet gevonden");

      if (tak.Leiding.Count > 0)
      {
        ModelState.AddModelError("LeidingAanwezig", "De tak bevat nog leiding.");
        return BadRequest(ModelStateFormatter.FormatErrors(ModelState));
      }

      _takRepository.Delete(tak);
      await _takRepository.SaveChangesAsync();
      var model = _mapper.Map<BasicTakViewModel>(tak);
      return Ok(model);
    }

    /// <summary>
    ///   Leiding van de opgegeven tak teruggeven zonder het takobject.
    /// </summary>
    /// <param name="id">Id (unieke identifier) van de tak</param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}/leiding")]
    public async Task<IActionResult> GetLeidingForTak([FromRoute] int id)
    {
      var tak = await _takRepository.FindByIdAsync(id);
      if (tak == null) return NotFound($"Tak met id {id} werd niet gevonden");

      var model = _mapper.Map<IEnumerable<BasicLeaderDTO>>(tak.Leiding);

      return Ok(model);
    }
  }
}
