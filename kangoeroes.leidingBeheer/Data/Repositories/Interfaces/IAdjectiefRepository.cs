using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Helpers;

namespace kangoeroes.leidingBeheer.Data.Repositories.Interfaces
{
    public interface IAdjectiefRepository
    {
        PagedList<Adjectief> FindAll(ResourceParameters resourceParameters);
        Task<Adjectief> FindByIdAsync(int id);
        Task<Adjectief> FindByNaamAsync(string naam);
        Task AddAsync(Adjectief adjectief);
        Task SaveChangesAsync();
    }
}