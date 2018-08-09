using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.ViewModels.ViewModels.Adjectief;

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
