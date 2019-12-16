using System.Collections.Generic;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Interfaces.Repositories
{
  public interface IOrderlineRepository: IBaseRepository<Orderline>
  {
    IEnumerable<PersonOrderlineSummary> GetPersonSummary(OrderlineResourceParameters parameters);
  }
}
