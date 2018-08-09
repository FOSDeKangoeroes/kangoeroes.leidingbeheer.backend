using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Models;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using kangoeroes.leidingBeheer.ViewModels.ViewModels.Leiding;
using kangoeroes.leidingBeheer.ViewModels.ViewModels.Tak;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer.Controllers
{
  public class TakController : BaseController
  {
    private readonly IMapper _mapper;
    private readonly ITakRepository _takRepository;

    public TakController(ITakRepository takRepository, IMapper mapper)
    {
      _takRepository = takRepository;
      _mapper = mapper;
    }

    /// <summary>
    ///   Geeft alle takken terug
    /// </summary>
    /// <returns>Lijst van alle takken</returns>
    [HttpGet] //GET api/tak
    public IActionResult Index([FromQuery] ResourceParameters resourceParameters)
    {
      var takken = _takRepository.FindAll(resourceParameters);

      var paginationMetaData = new
      {
        totalCount = takken.TotalCount,
        pageSize = takken.PageSize,
        currentPage = takken.CurrentPage,
        totalPages = takken.TotalPages
      };

      Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetaData));


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
      var tak = _mapper.Map<Tak>(viewmodel);
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


      tak = _mapper.Map(viewmodel, tak);

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

      var model = _mapper.Map<IEnumerable<BasicLeidingViewModel>>(tak.Leiding);

      return Ok(model);
    }
  }
}
