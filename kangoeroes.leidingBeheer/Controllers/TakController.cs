using System.Collections.Generic;
using AutoMapper;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Filters;
using kangoeroes.core.Models;
using kangoeroes.core.Models.Responses;
using kangoeroes.leidingBeheer.Models.ViewModels.Leiding;
using kangoeroes.leidingBeheer.Models.ViewModels.Tak;
using Microsoft.AspNetCore.Mvc;


namespace kangoeroes.leidingBeheer.Controllers
{
  [Route("/api/[controller]")]
  [ApiValidationFilter]
  public class TakController : Controller
  {
    private readonly ITakRepository _takRepository;
    private readonly IMapper _mapper;

    public TakController(ITakRepository takRepository, IMapper mapper)
    {
      _takRepository = takRepository;
      _mapper = mapper;
    }

    /// <summary>
    /// Geeft alle takken terug
    /// </summary>
    /// <returns>Lijst van alle takken</returns>
    [HttpGet] //GET api/tak
    public IActionResult Index([FromQuery] string sortBy = "naam", [FromQuery] string sortOrder ="",[FromQuery]  string query = "")
    {

      if (query == null)
      {
        query = "";
      }
      if (sortBy == null)
      {
        sortBy = "naam";
      }
      var sortString = sortBy + " " + sortOrder;
      var takken = _takRepository.FindAll(query,sortString);
      var model = _mapper.Map<IEnumerable<BasicTakViewModel>>(takken);
      return Ok(model);
    }

    /// <summary>
    /// Geef het tak object terug van de tak met opgegeven id.
    /// Wanneer de gegeven id niet overeenkomt met een bestaande tak, dan wordt een 404-error teruggegeven.
    /// </summary>
    /// <param name="id">Unieke identifier van de tak</param>
    /// <returns>1 tak object</returns>
    [Route("{id}")] //GET api/tak/{id}
    [HttpGet]
    public IActionResult GetTakById([FromRoute] int id)
    {
      var tak = _takRepository.FindById(id);
      if (tak == null)
      {
        return NotFound(new ApiResponse(404, $"Tak met id {id} werd niet gevonden"));
      }

      var model = _mapper.Map<BasicTakViewModel>(tak);

      return Ok(model);
    }

    /// <summary>
    /// Tak toevoegen met een naam en een volgorde. Id wordt toegekend door de database. Leiding wordt toegevoegd via de LeidingController
    /// </summary>
    /// <param name="viewmodel"></param>
    /// <returns></returns>
    [HttpPost] //POST /api/tak
    public IActionResult AddTak([FromBody] AddTakViewModel viewmodel)
    {
      var tak = _mapper.Map<Tak>(viewmodel);
      _takRepository.Add(tak);
      _takRepository.SaveChanges();
      var model = _mapper.Map<BasicTakViewModel>(tak);
      return CreatedAtRoute(tak.Id, model); //TODO: routes effectief juist implementeren
    }

    /// <summary>
    /// Updaten van de naam en/of volgorde van een tak. De meegegeven id bepaalt de te updaten tak. Leiding speelt geen rol.
    /// </summary>
    /// <param name="viewmodel"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut] //PUT /api/tak
    [Route("{id}")]
    public IActionResult UpdateTak( [FromRoute] int id,[FromBody] AddTakViewModel viewmodel)
    {
      var tak = _takRepository.FindById(id);

      if (tak == null)
      {
        return NotFound(new ApiResponse(404, $"Tak met id {id} werd niet gevonden"));
      }


      tak = _mapper.Map(viewmodel, tak);

      _takRepository.Update(tak);
      _takRepository.SaveChanges();
      var model = _mapper.Map<BasicTakViewModel>(tak);
      return Ok(model);
    }

    /// <summary>
    /// Verwijderen van tak met de gegeven id in de route
    /// </summary>
    /// <param name="id">Id van tak die verwijderd moet worden</param>
    /// <returns></returns>
    [Route("{id}")] //DELETE /api/tak/id
    [HttpDelete]
    public IActionResult DeleteTak([FromRoute] int id)
    {
      var tak = _takRepository.FindById(id);
      if (tak == null)
      {
        return NotFound(new ApiResponse(404, $"Tak met id {id} werd niet gevonden"));
      }

      if (tak.Leiding.Count > 0)
      {
        ModelState.AddModelError("LeidingAanwezig", "De tak bevat nog leiding.");
        return BadRequest(new ApiBadRequestResponse(ModelState));
      }

      _takRepository.Delete(tak);
      _takRepository.SaveChanges();
      var model = _mapper.Map<BasicTakViewModel>(tak);
      return Ok(model);
    }

    /// <summary>
    /// Leiding van de opgegeven tak teruggeven zonder het takobject.
    /// </summary>
    /// <param name="id">Id (unieke identifier) van de tak</param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}/leiding")]
    public IActionResult GetLeidingForTak([FromRoute] int id)
    {
      var tak = _takRepository.FindById(id);
      if (tak == null)
      {
        return NotFound(new ApiResponse(404, $"Tak met id {id} werd niet gevonden"));
      }

      var model = _mapper.Map<IEnumerable<BasicLeidingViewModel>>(tak.Leiding);

      return Ok(model);
    }

  }
}
