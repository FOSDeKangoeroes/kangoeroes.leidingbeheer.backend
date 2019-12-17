using System;
using System.Collections.Generic;
using kangoeroes.core.DTOs.Tab.Period;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Interfaces.Services
{
    public interface IPeriodService
    {
        IEnumerable<Period> GetAllPeriods();
        Period CreatePeriod(CreatePeriodDTO dto);
        Period UpdatePeriod(UpdatePeriodDTO dto);
        void DeletePeriod(int periodId);
    }
}