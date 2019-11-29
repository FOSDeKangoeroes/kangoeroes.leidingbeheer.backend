using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.core.Interfaces.Repositories
{
  public interface ITotemEntryRepository : IBaseRepository<TotemEntry>
  {
    Task<TotemEntry> FindByLeidingIdAsync(int leidingId);
    IEnumerable<TotemEntry> GetDescendants(int totemEntryId);
    IEnumerable<TotemEntry> GetFamilyTree();
  }
}
