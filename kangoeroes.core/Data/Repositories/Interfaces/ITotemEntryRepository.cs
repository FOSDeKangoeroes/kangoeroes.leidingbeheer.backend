using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.core.Data.Repositories.Interfaces
{
    public interface ITotemEntryRepository
    {
        PagedList<TotemEntry> FindAll(ResourceParameters resourceParameters);
        Task<TotemEntry> FindByIdAsync(int id);
        Task<TotemEntry> FindByLeidingIdAsync(int leidingId);
        Task AddAsync(TotemEntry totemEntry);
        Task DeleteAsync(TotemEntry totemEntry);
        Task SaveChangesAsync();
    }
}