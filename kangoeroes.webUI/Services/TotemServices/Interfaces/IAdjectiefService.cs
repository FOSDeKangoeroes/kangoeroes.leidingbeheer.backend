using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.DTOs.Adjective;
using kangoeroes.webUI.Helpers;

namespace kangoeroes.webUI.Services.TotemServices.Interfaces
{
  public interface IAdjectiefService
  {
    PagedList<Adjectief> FindAll(ResourceParameters resourceParameters);
    Task<BasicAdjectiveDTO> FindByIdAsync(int id);
    Task<BasicAdjectiveDTO> AddAdjectief(CreateAdjectiveDTO viewModel);
    Task<BasicAdjectiveDTO> UpdateAdjectief(int adjectiefId, UpdateAdjectiveDTO viewmodel);
  }
}
