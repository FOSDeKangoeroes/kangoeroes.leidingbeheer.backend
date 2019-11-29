using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.core.Interfaces.Repositories
{
  public interface IAdjectiefRepository : IBaseRepository<Adjectief>
  {
    Task<Adjectief> FindByNaamAsync(string naam);
  }
}
