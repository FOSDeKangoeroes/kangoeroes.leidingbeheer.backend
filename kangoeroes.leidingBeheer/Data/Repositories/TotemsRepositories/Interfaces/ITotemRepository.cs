using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.Data.Repositories.Interfaces;

namespace kangoeroes.webUI.Data.Repositories.TotemsRepositories.Interfaces
{
  public interface ITotemRepository : IBaseRepository<Totem>
  {
    Task<Totem> FindByNaamAsync(string naam);
    Task<Totem> TotemExists(string naam);
  }
}
