using System.Threading.Tasks;
using kangoeroes.core.Models.Poef;
using kangoeroes.webUI.Services.PoefServices.Interfaces;
using System.Collections.Generic;
using kangoeroes.core.DTOs.Tab.Drink;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;

namespace kangoeroes.webUI.Services.PoefServices
{
  public class DrankService : IDrankService
  {
    private readonly IDrankRepository _drankRepository;
    private readonly IDrankTypeRepository _drankTypeRepo;

    public DrankService(IDrankRepository drankRepository, IDrankTypeRepository drankTypeRepository)
    {
      _drankRepository = drankRepository;
      _drankTypeRepo = drankTypeRepository;
    }

    public PagedList<Drank> GetAll(ResourceParameters resourceParameters)
    {
      var result = _drankRepository.FindAll(resourceParameters);

      return result;
    }

    public async Task<Drank> GetDrankById(int drankId)
    {
      var drank = await _drankRepository.FindByIdAsync(drankId);

      if (drank == null) throw new EntityNotFoundException($"Drank met id {drankId} werd niet gevonden.");

      return drank;
    }

    public async Task<Drank> CreateDrank(CreateDrinkDTO viewModel)
    {
      //Zoeken naar type
      var type = await _drankTypeRepo.FindByIdAsync(viewModel.TypeId);

      if (type == null) throw new EntityNotFoundException($"Dranktype met id {viewModel.TypeId} werd niet gevonden.");

      var newDrank = Drank.Create(viewModel.Naam, viewModel.Prijs, type, viewModel.InStock);

      await _drankRepository.AddAsync(newDrank);
      await _drankRepository.SaveChangesAsync();

      return newDrank;
    }

    public async Task<Drank> UpdateDrank(int drankId, UpdateDrinkDTO viewModel)
    {
      var drank = await _drankRepository.FindByIdAsync(drankId);

      if (drank == null) throw new EntityNotFoundException($"Drank met id {drankId} werd niet gevonden");

      drank.Naam = viewModel.Naam;
      drank.InStock = viewModel.InStock;

      drank.TryAddNewPrijs(viewModel.Prijs);

      await _drankRepository.SaveChangesAsync();

      return drank;
    }

    public async Task DeleteDrank(int drankId)
    {
      var drankToDelete = await _drankRepository.FindByIdAsync(drankId);

      if (drankToDelete == null) throw new EntityNotFoundException($"Drank met id {drankId} werd niet gevonden.");

      _drankRepository.Delete(drankToDelete);
      await _drankRepository.SaveChangesAsync();
    }

        public async Task<PagedList<Drank>> GetDrankenForType(int drankTypeId, ResourceParameters resourceParameters)
        {
            var type = await _drankTypeRepo.FindByIdAsync(drankTypeId);

            if(type == null) {
              throw new EntityNotFoundException($"Type met id {drankTypeId} werd niet gevonden.");
            }

            var result = _drankRepository.GetDrankenForDrankType(drankTypeId, resourceParameters);

            return result;
     }

        public async Task<IEnumerable<Prijs>> GetPricesForDrank(int drankId)
        {
            return await _drankRepository.GetPricesForDrank(drankId);
        }
    }


}
