using System.Threading.Tasks;
using kangoeroes.core.Interfaces;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.webUI.Data.Repositories.TotemsRepositories.Interfaces
{
  public interface IAdjectiefRepository : IBaseRepository<Adjectief>
  {
    Task<Adjectief> FindByNaamAsync(string naam);
  }
}
