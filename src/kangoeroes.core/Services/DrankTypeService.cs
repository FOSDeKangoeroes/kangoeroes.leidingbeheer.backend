using System;
using System.Threading.Tasks;
using kangoeroes.core.DTOs.Tab.DrinkType;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Services
{
  /// <summary>
  /// Service voor het beheren van dranktypes
  /// </summary>
  public class DrankTypeService : IDrankTypeService
  {
    private readonly IDrankTypeRepository _drankTypeRepository;
    private readonly IDrankRepository _drankRepository;

    /// <summary>
    /// Maakt een nieuwe instantie aan van de service
    /// </summary>
    /// <param name="drankTypeRepository">Geïnjecteerde repository om types te lezen en schrijven naar de databank</param>
    public DrankTypeService(IDrankTypeRepository drankTypeRepository, IDrankRepository drankRepository)
    {
      _drankTypeRepository = drankTypeRepository;
      _drankRepository = drankRepository;
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
    /// <param name="dto">Model met gegevens voor het nieuwe type</param>
    /// <returns>Awaitable van het nieuw aangemaakte type</returns>
    public async Task<DrankType> CreateDrankType(CreateDrinkTypeDTO dto)
    {
      var existingType = await _drankTypeRepository.FindTypeByNaam(dto.Naam.Trim().ToLowerInvariant());

      if (existingType != null)
      {
        throw new EntityExistsException($"Er bestaat al een type met deze naam");
      }

      var newType = new DrankType()
      {
        Naam = dto.Naam.Trim()
      };

      await _drankTypeRepository.AddAsync(newType);
      await _drankTypeRepository.SaveChangesAsync();

      return newType;

    }

    /// <summary>
    /// Wijzigt velden van een bestaand dranktype naar de waarden gegeven in het model.
    /// </summary>
    /// <param name="dto">Model met nieuwe waarden voor het type</param>
    /// <param name="drankTypeId">Unieke sleutel van het te wijzigen type</param>
    /// <returns></returns>
    public async Task<DrankType> UpdateDrankType(UpdateDrinkTypeDTO dto, int drankTypeId)
    {
      var drankType = await _drankTypeRepository.FindByIdAsync(drankTypeId);

      if (drankType == null)
      {
        throw new EntityNotFoundException($"Type met id {drankTypeId} werd niet gevonden.");
      }

      drankType.Naam = dto.Naam;

      await _drankTypeRepository.SaveChangesAsync();

      return drankType;
    }

    /// <summary>
    /// Verwijdert een dranktype. Kan enkel uitgevoerd worden wanneer er geen dranken toegekend zijn aan het te verwijderen type
    /// </summary>
    /// <param name="drankTypeId">Unieke sleutel van het te verwijderen type</param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task DeleteDrankType(int drankTypeId)
    {
      var drankTypeToDelete = await _drankTypeRepository.FindByIdAsync(drankTypeId);

      if (drankTypeToDelete == null)
      {
        throw new EntityNotFoundException($"Type met id {drankTypeId} werd niet gevonden.");
      }

      //Bepalen of een type nog dranken onder zich heeft.
      var nrOfdrinksForType = await _drankRepository.CountDrankenForDrankType(drankTypeId);

      //We verwijderen geen type waaraan nog dranken gekoppeld zijn.
      if (nrOfdrinksForType > 0)
      {
        throw new DrinkTypeHasDrinksAttachedException($"{drankTypeToDelete.Naam} heeft nog {nrOfdrinksForType} drank(en) aan zich toegekend. Verwijder deze eerst.");
      }

      _drankTypeRepository.Delete(drankTypeToDelete);
      await _drankTypeRepository.SaveChangesAsync();

    }


  }
}
