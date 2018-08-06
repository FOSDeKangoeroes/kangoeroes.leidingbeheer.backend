using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Helpers;

namespace kangoeroes.leidingBeheer.Data.Repositories.Interfaces
{
    public interface ITotemEntryRepository: IBaseRepository<TotemEntry>
    {

        Task<TotemEntry> FindByLeidingIdAsync(int leidingId);
        IEnumerable<TotemEntry> GetDescendants(int totemEntryId);
        IEnumerable<TotemEntry> GetFamilyTree();
    }
}
