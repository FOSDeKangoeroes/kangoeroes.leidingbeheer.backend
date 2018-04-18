using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Models.ViewModels.TotemEntry;

namespace kangoeroes.leidingBeheer.Services.TotemServices.Interfaces
{
  public interface ITotemEntryService
  {
    PagedList<TotemEntry> FindAll(ResourceParameters resourceParameters);
    Task<BasicTotemEntryViewModel> FindByIdAsync(int id);
    Task<BasicTotemEntryViewModel> AddEntryAsync(AddEntryExistingLeiding viewmodel);
    Task<BasicTotemEntryViewModel> AddVoorOuderAsync(int leidingId, int voorouderId);
    Task<BasicTotemEntryViewModel> UpdateEntry(int entryId, UpdateTotemEntryViewModel viewmodel);
  }
}
