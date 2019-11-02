using kangoeroes.core.Models;

namespace kangoeroes.core.Interfaces
{
  public interface ITakRepository : IBaseRepository<Tak>
  {
    Tak FindByNaam(string name);
  }
}
