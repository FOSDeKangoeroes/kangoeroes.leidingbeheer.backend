using System.Threading.Tasks;
using kangoeroes.core.Models.Exceptions;
using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Services.PoefServices.Interfaces;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels;

namespace kangoeroes.leidingBeheer.Services.PoefServices
{
  public class DrankService : IDrankService
  {
    private readonly IDrankRepository _drankRepository;
    private readonly IBaseRepository<DrankType> _drankTypeRepo;

    public DrankService(IDrankRepository drankRepository)
    {
      _drankRepository = drankRepository;
    }

    public PagedList<Drank> GetAll(ResourceParameters resourceParameters)
    {
      var result = _drankRepository.FindAll(resourceParameters);

      return result;
    }

    public async Task<Drank> GetDrankById(int drankId)
    {
      var drank = await _drankRepository.FindByIdAsync(drankId);

      if (drank == null)
      {
        throw new EntityNotFoundException($"Drank met id {drankId} werd niet gevonden.");
      }

      return drank;
    }

    public async Task<Drank> CreateDrank(AddDrankViewModel viewModel)
    {
      //Zoeken naar type
      var type = await _drankTypeRepo.FindByIdAsync(viewModel.TypeId);

      if (type == null)
      {
        throw  new EntityNotFoundException($"Dranktype met id {viewModel.TypeId} werd niet gevonden.");
      }

      var newDrank = new Drank
      {
        InStock = viewModel.InStock,
        Naam = viewModel.Naam,
        Type = type
      };

      await _drankRepository.AddAsync(newDrank);
      await _drankRepository.SaveChangesAsync();

      return newDrank;
    }

    public async Task<Drank> UpdateDrank(int drankId, UpdateDrankViewModel viewModel)
    {
      var drank = await _drankRepository.FindByIdAsync(drankId);

      if (drank == null)
      {
        throw new EntityNotFoundException($"Drank met id {drankId} werd niet gevonden");
      }

      drank.Naam = viewModel.Naam;
      drank.InStock = viewModel.InStock;

      await _drankRepository.SaveChangesAsync();

      return drank;
    }

    public async Task DeleteDrank(int drankId)
    {
      var drankToDelete = await _drankRepository.FindByIdAsync(drankId);

      if (drankToDelete == null)
      {
        throw  new EntityNotFoundException($"Drank met id {drankId} werd niet gevonden.");
      }

      _drankRepository.Delete(drankToDelete);
      await _drankRepository.SaveChangesAsync();

    }




  }
}
