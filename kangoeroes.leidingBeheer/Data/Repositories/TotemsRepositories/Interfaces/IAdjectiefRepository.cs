using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.Data.Repositories.Interfaces;

namespace kangoeroes.webUI.Data.Repositories.TotemsRepositories.Interfaces
{
  public interface IAdjectiefRepository : IBaseRepository<Adjectief>
  {
    Task<Adjectief> FindByNaamAsync(string naam);
  }
}
