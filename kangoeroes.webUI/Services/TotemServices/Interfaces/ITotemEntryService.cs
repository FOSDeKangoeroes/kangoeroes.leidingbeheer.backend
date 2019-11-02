using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.DTOs.FamilyTree;
using kangoeroes.webUI.DTOs.TotemEntryViewModels;
using kangoeroes.webUI.Helpers;

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
    List<FamilyTreeDTO> GetFamilyTree();
  }
}
