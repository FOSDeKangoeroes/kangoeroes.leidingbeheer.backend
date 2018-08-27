using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;

namespace kangoeroes.leidingBeheer.Data.Repositories.PoefRepositories.Interfaces
{
  /// <summary>
  /// Repository klasse die verantwoordelijk is voor het lezen en schrijven van orders van/naar de database.
  /// </summary>
  public interface IOrderRepository: IBaseRepository<Order>
  {

  }
}
