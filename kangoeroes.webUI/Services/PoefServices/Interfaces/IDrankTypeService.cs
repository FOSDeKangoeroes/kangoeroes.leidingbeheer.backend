using System;
using System.Threading.Tasks;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Poef;
using kangoeroes.webUI.DTOs.Tab.DrinkType;
using kangoeroes.webUI.Helpers;

namespace kangoeroes.webUI.Services.PoefServices.Interfaces
{
  public interface IDrankTypeService
  {
    /// <summary>
    /// Geeft alle dranktypes terug, rekening houdend met de meegegeven parameters voor zoeken, sorteren en paginatie.
    /// </summary>
    /// <param name="resourceParameters">Parameters voor zoeken, sorteren en paginatie</param>
    /// <returns></returns>
    PagedList<DrankType> GetAll(ResourceParameters resourceParameters);

    /// <summary>
    /// Haalt een type op uit de databank aan de hand van de gegeven unieke sleutel. Geeft EntityNotFoundException wanneer het type niet werd gevonden.
    /// </summary>
    /// <param name="typeId">Unieke sleutel van het gevraagde type</param>
    /// <returns>Een awaitable van het type</returns>
    /// <exception cref="EntityNotFoundException">Wordt opgegooid wanneer de gevraagde entiteit null is.</exception>
    Task<DrankType> GetDrankTypeById(int typeId);

    /// <summary>
    /// Maakt een nieuw dranktype aan de hand van het gegeven model en slaat dit op in de database.
    /// </summary>
    /// <param name="viewModel">Model met gegevens voor het nieuwe type</param>
    /// <returns>Awaitable van het nieuw aangemaakte type</returns>
    Task<DrankType> CreateDrankType(AddDrankTypeViewModel viewModel);

    /// <summary>
    /// Wijzigt velden van een bestaand dranktype naar de waarden gegeven in het model.
    /// </summary>
    /// <param name="viewModel">Model met nieuwe waarden voor het type</param>
    /// <param name="drankTypeId">Unieke sleutel van het te wijzigen type</param>
    /// <returns></returns>
    Task<DrankType> UpdateDrankType(UpdateDrankTypeViewModel viewModel, int drankTypeId);

    /// <summary>
    /// Verwijdert een dranktype. Kan enkel uitgevoerd worden wanneer er geen dranken toegekend zijn aan het te verwijderen type
    /// </summary>
    /// <param name="drankTypeId">Unieke sleutel van het te verwijderen type</param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    Task DeleteDrankType(int drankTypeId);
  }
}
