using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.Helpers;
using kangoeroes.webUI.Helpers.ResourceParameters;
using kangoeroes.webUI.ViewModels.AdjectiefViewModels;

namespace kangoeroes.webUI.Services.TotemServices.Interfaces
{
  public interface IAdjectiefService
  {
    PagedList<Adjectief> FindAll(ResourceParameters resourceParameters);
    Task<BasicAdjectiefViewModel> FindByIdAsync(int id);
    Task<BasicAdjectiefViewModel> AddAdjectief(AddAdjectiefViewModel viewModel);
    Task<BasicAdjectiefViewModel> UpdateAdjectief(int adjectiefId, UpdateAdjectiefViewModel viewmodel);
  }
}
