using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.core.Data.Repositories.Interfaces
{
    public interface IAdjectiefRepository
    {
        IEnumerable<Adjectief> FindAll();
        Task<Adjectief> FindByIdAsync(int id);
        Task<Adjectief> FindByNaamAsync(string naam);
        Task AddAsync(Adjectief adjectief);
        Task SaveChangesAsync();
    }
}