using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Models.Poef;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.infrastructure.Repositories.PoefRepositories
{
    public class PeriodRepository: BaseRepository<Period>, IPeriodRepository
    {
        private readonly DbSet<Period> _periods;
        public PeriodRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _periods = dbContext.Periods;
        }

        public override PagedList<Period> FindAll(ResourceParameters resourceParameters)
        {
            throw new System.NotImplementedException();
        }

        public override Task<Period> FindByIdAsync(int id)
        {
            return _periods.FirstOrDefaultAsync(x => x.Id == id);
        }
        
    }
}