using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using kangoeroes.core.Data.Context;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models.Totems;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.core.Data.Repositories
{
    public class TotemEntryRepository : ITotemEntryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TotemEntry> _totemEntries;

        public TotemEntryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _totemEntries = _dbContext.TotemEntries;
        }

        private IQueryable<TotemEntry> GetAllWithAllIncluded()
        {
            return _totemEntries.Include(x => x.Adjectief).Include(x => x.Leiding).Include(x => x.Totem)
                .Include(x => x.Voorouder).ThenInclude(x => x.Adjectief).Include(x => x.Voorouder).ThenInclude(x => x.Totem);
        }
        
        public PagedList<TotemEntry> FindAll(ResourceParameters resourceParameters)
        {
            var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

            var collectionBeforePaging = GetAllWithAllIncluded();
            
            if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
            {
                collectionBeforePaging = collectionBeforePaging.Where(x => x.Totem.Naam.ToLowerInvariant().Trim()
                    .Contains(resourceParameters.Query.ToLowerInvariant().Trim()));
            }

            if (!string.IsNullOrWhiteSpace(sortString))
            {
                collectionBeforePaging = collectionBeforePaging.OrderBy(sortString);
            }
              
            var pagedList = PagedList<TotemEntry>.Create(collectionBeforePaging, resourceParameters.PageNumber, resourceParameters.PageSize);

            return pagedList;
            
        }

        public Task<TotemEntry> FindByIdAsync(int id)
        {
            return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<TotemEntry> FindByLeidingIdAsync(int leidingId)
        {
            return _totemEntries.Include(x => x.Leiding).FirstOrDefaultAsync(x => x.Leiding.Id == leidingId);
        }

        public Task AddAsync(TotemEntry totemEntry)
        {
            return _totemEntries.AddAsync(totemEntry);
        }

        public Task DeleteAsync(TotemEntry totemEntry)
        {
            return _totemEntries.AddAsync(totemEntry);
        }

        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}