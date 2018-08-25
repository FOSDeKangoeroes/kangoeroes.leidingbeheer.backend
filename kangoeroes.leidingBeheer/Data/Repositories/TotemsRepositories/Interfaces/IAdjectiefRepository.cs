using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;

namespace kangoeroes.leidingBeheer.Data.Repositories.TotemsRepositories.Interfaces
{
  public interface IAdjectiefRepository : IBaseRepository<Adjectief>
  {
    Task<Adjectief> FindByNaamAsync(string naam);
  }
}
