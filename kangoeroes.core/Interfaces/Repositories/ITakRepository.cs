using kangoeroes.core.Models;

namespace kangoeroes.core.Interfaces.Repositories
{
  public interface ITakRepository : IBaseRepository<Tak>
  {
    Tak FindByNaam(string name);
  }
}
