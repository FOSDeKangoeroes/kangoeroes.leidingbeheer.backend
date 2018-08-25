using kangoeroes.core.Models;

namespace kangoeroes.leidingBeheer.Data.Repositories.Interfaces
{
  public interface ITakRepository : IBaseRepository<Tak>
  {
    Tak FindByNaam(string name);
  }
}
