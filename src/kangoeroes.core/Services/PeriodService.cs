using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.DTOs.Tab.Period;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Services
{
    public class PeriodService: IPeriodService
    {
        private readonly IPeriodRepository _periodRepository;
        
        public PeriodService(IPeriodRepository periodRepository)
        {
            _periodRepository = periodRepository;
        }

        public PagedList<Period> GetAllPeriods(ResourceParameters resourceParameters)
        {
            return _periodRepository.FindAll(resourceParameters);
        }

        public async Task<Period> CreatePeriod(CreatePeriodDTO dto)
        {
            var newPeriod = new Period
            {
                Name = dto.Name.Trim(),
                Start = dto.Start.Date,
                End = dto.End.Date
            };

            await _periodRepository.AddAsync(newPeriod);
            await _periodRepository.SaveChangesAsync();

            return newPeriod;
        }

        public async Task<Period> UpdatePeriod(int periodId, UpdatePeriodDTO dto)
        {
            var periodToUpdate = await _periodRepository.FindByIdAsync(periodId);

            if (periodToUpdate == null)
            {
                throw new EntityNotFoundException($"Periode met ID {periodId} werd niet gevonden.");
            }

            periodToUpdate.Name = dto.Name.Trim();
            if (dto.Start.HasValue)
            {
                periodToUpdate.Start = dto.Start.Value.Date;
            }

            if (dto.End.HasValue)
            {
                periodToUpdate.End = dto.End.Value.Date;
            }

            await _periodRepository.SaveChangesAsync();
            return periodToUpdate;
        }

        public async Task DeletePeriod(int periodId)
        {
            var periodToDelete = await _periodRepository.FindByIdAsync(periodId);
            if (periodToDelete == null)
            {
                throw new EntityNotFoundException($"Periode met ID {periodId} werd niet gevonden.");
            }
            _periodRepository.Delete(periodToDelete);
            await _periodRepository.SaveChangesAsync();
        }
    }
}