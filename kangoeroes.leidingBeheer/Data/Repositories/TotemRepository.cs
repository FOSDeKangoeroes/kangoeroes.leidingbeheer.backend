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
    public class TotemRepository : ITotemRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Totem> _totems;

        public TotemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _totems = _dbContext.Totems;
        }

        private IQueryable<Totem> GetAllWithAllIncluded()
        {
            return _totems;
        }

        public PagedList<Totem> FindAll(ResourceParameters resourceParameters)
        {
            var result = GetAllWithAllIncluded();
            
            var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

            if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
            {
                result = result.Where(x => x.Naam.Contains(resourceParameters.Query));
                                           
            }
            
            
            if (!string.IsNullOrWhiteSpace(sortString))
            {
                result = result.OrderBy(sortString);
            }

            var pagedList = PagedList<Totem>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

            return pagedList;
        }

        public Task<Totem> FindByIdAsync(int id)
        {
            return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Totem> FindByNaamAsync(string naam)
        {
            return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Naam == naam);
        }

        public Task AddAsync(Totem totem)
        {
           return _totems.AddAsync(totem);
        }

        public void Delete(Totem totem)
        {
             _totems.Remove(totem);
        }

        public Task SaveChangesAsync()
        {
           return _dbContext.SaveChangesAsync();
        }

        public Task<Totem> TotemExists(string naam)
        {
            return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Matches(naam));
        }
    }
}
