using System.Threading.Tasks;
using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;

namespace kangoeroes.leidingBeheer.Data.Repositories.PoefRepositories.Interfaces
{
  /// <summary>
  /// Repository interface verantwoordelijk voor het definieren van het contract voor het lezen en schrijven van alle data rond dranktypes.
  /// </summary>
  public interface IDrankTypeRepository: IBaseRepository<DrankType>
  {
    Task<DrankType> FindTypeByNaam(string naam);
  }
}
