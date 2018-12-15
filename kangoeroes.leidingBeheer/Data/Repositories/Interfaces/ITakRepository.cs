using kangoeroes.core.Models;

namespace kangoeroes.webUI.Data.Repositories.Interfaces
{
  public interface ITakRepository : IBaseRepository<Tak>
  {
    Tak FindByNaam(string name);
  }
}
