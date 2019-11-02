using System.Threading.Tasks;
using kangoeroes.core.Interfaces;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.webUI.Data.Repositories.TotemsRepositories.Interfaces
{
  public interface ITotemRepository : IBaseRepository<Totem>
  {
    Task<Totem> FindByNaamAsync(string naam);
    Task<Totem> TotemExists(string naam);
  }
}
