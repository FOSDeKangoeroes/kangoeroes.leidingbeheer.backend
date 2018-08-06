using kangoeroes.core.Models;
using kangoeroes.leidingBeheer.Helpers;

namespace kangoeroes.leidingBeheer.Data.Repositories.Interfaces
{
    public interface ITakRepository: IBaseRepository<Tak>
    {
        Tak FindByNaam(string name);
    }
}
