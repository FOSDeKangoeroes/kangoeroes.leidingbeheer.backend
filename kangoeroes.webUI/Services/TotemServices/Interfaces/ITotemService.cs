using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.Helpers;
using kangoeroes.webUI.ViewModels.TotemViewModels;

namespace kangoeroes.webUI.Services.TotemServices.Interfaces
{
  public interface ITotemService
  {
    PagedList<Totem> FindAll(ResourceParameters resourceParameters);
    Task<BasicTotemViewModel> FindByIdAsync(int id);
    Task<BasicTotemViewModel> AddTotemAsync(AddTotemViewModel viewModel);
    Task<BasicTotemViewModel> UpdateTotemAsync(UpdateTotemViewModel viewModel, int id);
  }
}
