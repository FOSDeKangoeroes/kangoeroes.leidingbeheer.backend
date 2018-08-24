using System;
using System.Threading.Tasks;
using kangoeroes.core.Models.Exceptions;
using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.Data.Repositories.PoefRepositories.Interfaces;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.DrankType;

namespace kangoeroes.leidingBeheer.Services.PoefServices
{
  /// <summary>
  /// Service voor het beheren van dranktypes
  /// </summary>
  public class DrankTypeService
  {
    private readonly IDrankTypeRepository _drankTypeRepository;

    /// <summary>
    /// Maakt een nieuwe instantie aan van de service
    /// </summary>
    /// <param name="drankTypeRepository">Geïnjecteerde repository om types te lezen en schrijven naar de databank</param>
    public DrankTypeService(IDrankTypeRepository drankTypeRepository)
    {
      _drankTypeRepository = drankTypeRepository;
    }

    /// <summary>
    /// Geeft alle dranktypes terug, rekening houdend met de meegegeven parameters voor zoeken, sorteren en paginatie.
    /// </summary>
    /// <param name="resourceParameters">Parameters voor zoeken, sorteren en paginatie</param>
    /// <returns></returns>
    public PagedList<DrankType> GetAll(ResourceParameters resourceParameters)
    {
      var types = _drankTypeRepository.FindAll(resourceParameters);

      return types;
    }

    /// <summary>
    /// Haalt een type op uit de databank aan de hand van de gegeven unieke sleutel. Geeft EntityNotFoundException wanneer het type niet werd gevonden.
    /// </summary>
    /// <param name="typeId">Unieke sleutel van het gevraagde type</param>
    /// <returns>Een awaitable van het type</returns>
    /// <exception cref="EntityNotFoundException">Wordt opgegooid wanneer de gevraagde entiteit null is.</exception>
    public async Task<DrankType> GetDrankTypeById(int typeId)
    {
      var drankType = await _drankTypeRepository.FindByIdAsync(typeId);

      if (drankType == null)
      {
        throw new EntityNotFoundException($"Type met id {typeId} werd niet gevonden.");
      }

      return drankType;
    }

    /// <summary>
    /// Maakt een nieuw dranktype aan de hand van het gegeven model en slaat dit op in de database.
    /// </summary>
    /// <param name="viewModel">Model met gegevens voor het nieuwe type</param>
    /// <returns>Awaitable van het nieuw aangemaakte type</returns>
    public async Task<DrankType> CreateDrankType(AddDrankTypeViewModel viewModel)
    {
      var newType = new DrankType()
      {
        Naam = viewModel.Naam
      };

      await _drankTypeRepository.AddAsync(newType);
      await _drankTypeRepository.SaveChangesAsync();

      return newType;

    }

    /// <summary>
    /// Wijzigt velden van een bestaand dranktype naar de waarden gegeven in het model.
    /// </summary>
    /// <param name="viewModel">Model met nieuwe waarden voor het type</param>
    /// <param name="drankTypeId">Unieke sleutel van het te wijzigen type</param>
    /// <returns></returns>
    public async Task<DrankType> UpdateDrankType(UpdateDrankTypeViewModel viewModel, int drankTypeId)
    {
      var drankType = await _drankTypeRepository.FindByIdAsync(drankTypeId);

      if (drankType == null)
      {
        throw new EntityNotFoundException($"Type met id {drankTypeId} werd niet gevonden.");
      }

      drankType.Naam = viewModel.Naam;

      await _drankTypeRepository.SaveChangesAsync();

      return drankType;
    }


  }
}
