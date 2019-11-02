using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Interfaces;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.webUI.Data.Repositories.TotemsRepositories.Interfaces
{
  public interface ITotemEntryRepository : IBaseRepository<TotemEntry>
  {
    Task<TotemEntry> FindByLeidingIdAsync(int leidingId);
    IEnumerable<TotemEntry> GetDescendants(int totemEntryId);
    IEnumerable<TotemEntry> GetFamilyTree();
  }
}
