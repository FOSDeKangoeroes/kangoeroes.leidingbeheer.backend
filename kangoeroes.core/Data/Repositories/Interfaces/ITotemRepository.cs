using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.core.Data.Repositories.Interfaces
{
    public interface ITotemRepository
    {
        PagedList<Totem> FindAll(ResourceParameters resourceParameters);
        Task<Totem> FindByIdAsync(int id);
        Task<Totem> FindByNaamAsync(string naam);
        Task AddAsync(Totem totem);
        void Delete(Totem totem);
        Task SaveChangesAsync();
        Task<Totem> TotemExists(string naam);

    }
}