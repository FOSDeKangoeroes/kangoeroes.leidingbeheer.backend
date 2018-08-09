using System.Threading.Tasks;
using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels;

namespace kangoeroes.leidingBeheer.Services.PoefServices.Interfaces
{
  public interface IDrankService
  {
    PagedList<Drank> GetAll(ResourceParameters resourceParameters);
    Task<Drank> GetDrankById(int drankId);
    Task<Drank> CreateDrank(AddDrankViewModel viewModel);
    Task<Drank> UpdateDrank(int drankId, UpdateDrankViewModel viewModel);
    Task DeleteDrank(int drankId);
  }
}
