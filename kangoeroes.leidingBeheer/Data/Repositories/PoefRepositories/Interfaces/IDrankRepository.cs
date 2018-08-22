﻿using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;

namespace kangoeroes.leidingBeheer.Data.Repositories.PoefRepositories.Interfaces
{
  /// <summary>
  /// Repository interface die het contract definieert rond het lezen en schrijven van alle data rond dranken
  /// </summary>
  public interface IDrankRepository : IBaseRepository<Drank>
  {
  }
}
