using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.core.Interfaces.Repositories
{
  public interface ITotemRepository : IBaseRepository<Totem>
  {
    Task<Totem> FindByNaamAsync(string naam);
    Task<DateTime> GetEarliestReuseDateForTotem(int id);
    Dictionary<int, int> GetCountOfEntriesForTotems();

  }
}
