using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.core.Interfaces.Repositories
{
  public interface ITotemRepository : IBaseRepository<Totem>
  {
    Task<Totem> FindByNaamAsync(string naam);
    Task<Totem> TotemExists(string naam);
  }
}
