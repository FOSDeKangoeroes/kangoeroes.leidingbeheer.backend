using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Helpers;

namespace kangoeroes.leidingBeheer.Data.Repositories.Interfaces
{
    public interface ITotemEntryRepository
    {
        PagedList<TotemEntry> FindAll(ResourceParameters resourceParameters);
        Task<TotemEntry> FindByIdAsync(int id);
        Task<TotemEntry> FindByLeidingIdAsync(int leidingId);
        Task AddAsync(TotemEntry totemEntry);
        Task DeleteAsync(TotemEntry totemEntry);
        IEnumerable<TotemEntry> GetDescendants(int totemEntryId);
        IEnumerable<TotemEntry> GetFamilyTree();
        Task SaveChangesAsync();
    }
}