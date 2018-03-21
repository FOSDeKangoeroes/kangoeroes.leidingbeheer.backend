using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.leidingBeheer.Models.ViewModels.Totem;

namespace kangoeroes.leidingBeheer.Services.TotemServices.Interfaces
{
  public interface ITotemService
  {
    IEnumerable<BasicTotemViewModel> FindAll();
    Task<BasicTotemViewModel> FindByIdAsync(int id);
    Task<BasicTotemViewModel> AddTotemAsync(AddTotemViewModel viewModel);
    Task<BasicTotemViewModel> UpdateTotemAsync(UpdateTotemViewModel viewModel, int id);
  }
}
