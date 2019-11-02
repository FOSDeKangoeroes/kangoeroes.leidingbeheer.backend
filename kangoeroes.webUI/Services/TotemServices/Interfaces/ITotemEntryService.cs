using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.DTOs.FamilyTree;
using kangoeroes.core.DTOs.TotemEntry;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.Helpers;

namespace kangoeroes.webUI.Services.TotemServices.Interfaces
{
  public interface ITotemEntryService
  {
    PagedList<TotemEntry> FindAll(ResourceParameters resourceParameters);
    Task<BasicTotemEntryDTO> FindByIdAsync(int id);
    Task<BasicTotemEntryDTO> AddEntryAsync(CreateTotemEntryDTO viewmodel);
    Task<BasicTotemEntryDTO> AddVoorOuderAsync(int leidingId, int voorouderId);
    Task<BasicTotemEntryDTO> UpdateEntry(int entryId, UpdateTotemEntryDTO viewmodel);
    List<BasicTotemEntryDTO> GetDescendants(int entryId);
    List<FamilyTreeDTO> GetFamilyTree();
  }
}
