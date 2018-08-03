using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Helpers;

namespace kangoeroes.leidingBeheer.Data.Repositories.Interfaces
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