using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Data.Context;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;
using kangoeroes.leidingBeheer.Helpers;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.leidingBeheer.Data.Repositories
{
    public class AdjectiefRepository: IAdjectiefRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Adjectief> _adjectieven;

        public AdjectiefRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _adjectieven = dbContext.Adjectieven;
        }
        
        public PagedList<Adjectief> FindAll(ResourceParameters resourceParameters)
        {
            var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

            var result = _adjectieven.AsQueryable();
            

            if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
            {
                result = result.Where(x => x.Naam.ToLowerInvariant().Trim()
                .Contains(resourceParameters.Query.ToLowerInvariant().Trim()));

            }

            if (!string.IsNullOrWhiteSpace(sortString))
            {
                result = result.OrderBy(sortString);
            }
              
            var pagedList = PagedList<Adjectief>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

            return pagedList;
        }

        public Task<Adjectief> FindByIdAsync(int id)
        {
            return _adjectieven.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Adjectief> FindByNaamAsync(string naam)
        {
            return _adjectieven.FirstOrDefaultAsync(x => x.Naam == naam);
        }

        public Task AddAsync(Adjectief adjectief)
        {
           return _adjectieven.AddAsync(adjectief);
        }

        public Task SaveChangesAsync()
        {
           return _dbContext.SaveChangesAsync();
        }
    }
}