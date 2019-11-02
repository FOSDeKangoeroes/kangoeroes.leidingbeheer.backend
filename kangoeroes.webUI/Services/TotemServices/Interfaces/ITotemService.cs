using System.Threading.Tasks;
using kangoeroes.core.DTOs.Animal;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.Helpers;

namespace kangoeroes.webUI.Services.TotemServices.Interfaces
{
  public interface ITotemService
  {
    PagedList<Totem> FindAll(ResourceParameters resourceParameters);
    Task<BasicAnimalDTO> FindByIdAsync(int id);
    Task<BasicAnimalDTO> AddTotemAsync(AddAnimalDTO viewModel);
    Task<BasicAnimalDTO> UpdateTotemAsync(UpdateAnimalDTO viewModel, int id);
  }
}
