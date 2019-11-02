using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.DTOs.Tab.Drink;
using kangoeroes.core.DTOs.Tab.Price;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.webUI.Interfaces;
using kangoeroes.webUI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kangoeroes.webUI.Controllers.PoefControllers
{
    /// <summary>
    /// Controller met alle endpoints voor het beheren van dranken.
    /// </summary>
    public class DrankController : BaseController
    {
        private readonly IDrankService _drankService;
        private readonly IMapper _mapper;
        private readonly IPaginationMetaDataService _paginationMetaDataService;


        /// <summary>
        /// Maakt een nieuwe instantie aan van de DrankController
        /// </summary>
        /// <param name="drankService">Service verantwoordelijk voor het uitvoeren van businesslogice ivm dranken</param>
        /// <param name="mapper">Instantie van automapper om entiteiten teruggegeven door de service om te zetten naar viewmodels.</param>
        /// <param name="paginationMetaDataService">Service voor het toevoegen van paginatie metadata aan de response headers</param>
        public DrankController(IDrankService drankService, IMapper mapper, IPaginationMetaDataService paginationMetaDataService)
        {
            _drankService = drankService;
            _mapper = mapper;
            _paginationMetaDataService = paginationMetaDataService;
        }

        /// <summary>
        /// Geeft een OK (200) met een viewmodel van alle dranken, gepagineerd en gefilterd volgens de meegegeven query parameters
        /// </summary>
        /// <param name="resourceParameters"> Query parameters voor het pagineren en filteren van dranken</param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<BasicDrinkDTO>), 200)]
        public IActionResult GetAll([FromQuery] ResourceParameters resourceParameters)
        {
            var dranken = _drankService.GetAll(resourceParameters);

            _paginationMetaDataService.AddMetaDataToResponse(Response, dranken);

            var model = _mapper.Map<IEnumerable<BasicDrinkDTO>>(dranken);
            return Ok(model);
        }

        /// <summary>
        /// Endpoint voor het ophalen van een specifieke drank aan de hand van de unieke sleutel.
        /// </summary>
        /// <param name="drankId">Unieke sleutel van de gevraagde drank.</param>
        /// <returns> OK (200) - BasicDrinkDTO van de gevraagde drank.</returns>
        /// <returns>Not Found (404) - Foutboodschap, drank werd niet gevonden.</returns>
        [HttpGet("{drankId}", Name = "FindDrankById")]
        [ProducesResponseType(typeof(BasicDrinkDTO), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> FindByIdAsync([FromRoute] int drankId)
        {
            try
            {
                var drank = await _drankService.GetDrankById(drankId);
                var model = _mapper.Map<BasicDrinkDTO>(drank);

                return Ok(model);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Endpoint voor het toevoegen van een nieuwe drank aan een reeds bestaand type.
        /// </summary>
        /// <param name="viewModel">Body met alle nodige data voor het creeeren van ene nieuwe drank</param>
        /// <returns>Created (201) - Model van de nieuw aangemaakte drank</returns>
        /// <returns>Not Found (404) - Opgegeven type voor de drank werd niet gevonden</returns>
        /// <returns>Bad Request (400) - Data opgegeven voldoet niet aan de validatie eisen.</returns>
        [HttpPost("")]
        [ProducesResponseType(typeof(BasicDrinkDTO), 201)]
        [ProducesResponseType(typeof(IEnumerable<string>), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> CreateDrank([FromBody] CreateDrinkDTO viewModel)
        {
            try
            {
                var drank = await _drankService.CreateDrank(viewModel);
                var model = _mapper.Map<BasicDrinkDTO>(drank);

                return CreatedAtRoute("FindDrankById", new { drankId = drank.Id }, model);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Endpoint voor het wijzigen van een drank.  Dit endpoint wijzigt alle velden naar de waarden gegeven in het model.
        /// Een  optioneel veld in het viewmodel wordt dus leeggemaakt indien dit in het viewmodel leeg is.
        /// </summary>
        /// <param name="viewModel">Model met de nieuwe gegevens van de drank.</param>
        /// <param name="drankId">Unieke sleutel van de te wijzigen drank.</param>
        /// <returns>Een model van de gewijzigde drank.</returns>
        [HttpPut("{drankId}")]
        [ProducesResponseType(typeof(BasicDrinkDTO), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> UpdateDrank([FromBody] UpdateDrinkDTO viewModel, [FromRoute] int drankId)
        {
            try
            {
                var drank = await _drankService.UpdateDrank(drankId, viewModel);

                var model = _mapper.Map<BasicDrinkDTO>(drank);

                return Ok(model);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Endpoint dat alle prijzen die een drank ooit heeft gehad teruggeeft
        /// </summary>
        /// <param name="drankId">Unieke sleutel van de drank waarvoor de prijzen gevraagd zijn.</param>
        /// <returns>Lijst van alle prijzen die de drank heeft (gehad)</returns>
        [HttpGet("{drankId}/price")]
        [ProducesResponseType(typeof(BasicDrinkDTO), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetPrices([FromRoute] int drankId)
        {
            var prices = await _drankService.GetPricesForDrank(drankId);

            var model = _mapper.Map<IEnumerable<BasicPriceDTO>>(prices);
            return Ok(model);
        }
    }
}
