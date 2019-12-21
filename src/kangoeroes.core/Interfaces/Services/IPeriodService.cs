using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.DTOs.Tab.Period;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Interfaces.Services
{
    public interface IPeriodService
    {
        PagedList<Period> GetAllPeriods(ResourceParameters resourceParameters);
        Task<Period> CreatePeriod(CreatePeriodDTO dto);
        Task<Period> UpdatePeriod(int periodId, UpdatePeriodDTO dto);
        Task DeletePeriod(int periodId);
    }
}