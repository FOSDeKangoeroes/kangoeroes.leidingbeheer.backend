using System.Threading.Tasks;
using kangoeroes.core.DTOs.Adjective;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.core.Interfaces.Services
{
  public interface IAdjectiefService
  {
    PagedList<Adjectief> FindAll(ResourceParameters resourceParameters);
    Task<BasicAdjectiveDTO> FindByIdAsync(int id);
    Task<BasicAdjectiveDTO> AddAdjectief(CreateAdjectiveDTO viewModel);
    Task<BasicAdjectiveDTO> UpdateAdjectief(int adjectiefId, UpdateAdjectiveDTO viewmodel);
  }
}
