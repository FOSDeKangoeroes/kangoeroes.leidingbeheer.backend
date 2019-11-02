using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.Helpers;
using kangoeroes.webUI.ViewModels.FamilyTreeViewModels;
using kangoeroes.webUI.ViewModels.TotemEntryViewModels;

namespace kangoeroes.webUI.Services.TotemServices.Interfaces
{
  public interface ITotemEntryService
  {
    PagedList<TotemEntry> FindAll(ResourceParameters resourceParameters);
    Task<BasicTotemEntryViewModel> FindByIdAsync(int id);
    Task<BasicTotemEntryViewModel> AddEntryAsync(AddEntryExistingLeiding viewmodel);
    Task<BasicTotemEntryViewModel> AddVoorOuderAsync(int leidingId, int voorouderId);
    Task<BasicTotemEntryViewModel> UpdateEntry(int entryId, UpdateTotemEntryViewModel viewmodel);
    List<BasicTotemEntryViewModel> GetDescendants(int entryId);
    List<FamilyTreeViewModel> GetFamilyTree();
  }
}
