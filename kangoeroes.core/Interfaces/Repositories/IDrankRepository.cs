using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Interfaces.Repositories
{
    /// <summary>
    /// Repository interface die het contract definieert rond het lezen en schrijven van alle data rond dranken
    /// </summary>
    public interface IDrankRepository : IBaseRepository<Drank>
    {
        /// <summary>
        /// Geeft het aantal dranken terug die behoren tot een bepaald type.
        /// </summary>
        /// <param name="drankTypeId">Dranktype waarvoor het aantal dranken gevraagd is</param>
        /// <returns>Een integer die aangeeft hoeveel dranken een dranktype bevat.</returns>
        Task<int> CountDrankenForDrankType(int drankTypeId);
        PagedList<Drank> GetDrankenForDrankType(int drankTypeId, ResourceParameters resourceParameters);

        Task<IEnumerable<Prijs>> GetPricesForDrank(int drankId);
    }
}
