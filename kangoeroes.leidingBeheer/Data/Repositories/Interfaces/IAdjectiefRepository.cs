using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Helpers;

namespace kangoeroes.leidingBeheer.Data.Repositories.Interfaces
{
    public interface IAdjectiefRepository: IBaseRepository<Adjectief>
    {
        Task<Adjectief> FindByNaamAsync(string naam);
    }
}
