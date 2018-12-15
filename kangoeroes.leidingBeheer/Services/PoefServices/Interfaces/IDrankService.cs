using System.Threading.Tasks;
using kangoeroes.core.Models.Poef;
using kangoeroes.webUI.ViewModels.PoefViewModels;
using kangoeroes.webUI.Helpers;
using kangoeroes.webUI.Helpers.ResourceParameters;
using kangoeroes.webUI.ViewModels.PoefViewModels.Drank;

namespace kangoeroes.webUI.Services.PoefServices.Interfaces
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
