using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.core.Data.Repositories.Interfaces
{
    public interface ITotemRepository
    {
        IEnumerable<Totem> FindAll();
        Task<Totem> FindByIdAsync(int id);
        Task<Totem> FindByNaamAsync(string naam);
        Task AddAsync(Totem totem);
        void Delete(Totem totem);
        Task SaveChangesAsync();
        Task<Totem> TotemExists(string naam);

    }
}