using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using kangoeroes.leidingBeheer.ViewModels.AdjectiefViewModels;

namespace kangoeroes.leidingBeheer.Services.TotemServices.Interfaces
{
  public interface IAdjectiefService
  {
    PagedList<Adjectief> FindAll(ResourceParameters resourceParameters);
    Task<BasicAdjectiefViewModel> FindByIdAsync(int id);
    Task<BasicAdjectiefViewModel> AddAdjectief(AddAdjectiefViewModel viewModel);
    Task<BasicAdjectiefViewModel> UpdateAdjectief(int adjectiefId, UpdateAdjectiefViewModel viewmodel);
  }
}
