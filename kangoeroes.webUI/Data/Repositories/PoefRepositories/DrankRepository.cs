using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Poef;
using kangoeroes.webUI.Data.Context;
using kangoeroes.webUI.Data.Repositories.PoefRepositories.Interfaces;
using kangoeroes.webUI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.webUI.Data.Repositories.PoefRepositories
{
    public class DrankRepository : BaseRepository<Drank>, IDrankRepository
    {
        private readonly DbSet<Drank> _dranken;

        public DrankRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dranken = dbContext.Dranken;
        }

        public override PagedList<Drank> FindAll(ResourceParameters resourceParameters)
        {

            var result = GetAllWithAllIncluded();

            result = FilterDrinks(result, resourceParameters.Query);

            result = SortDrinks(result, resourceParameters.SortBy, resourceParameters.SortOrder);

            var pagedList = PagedList<Drank>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

            return pagedList;
        }

        public override Task<Drank> FindByIdAsync(int id)
        {
            return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<int> CountDrankenForDrankType(int drankTypeId)
        {
            return _dranken.Include(x => x.Type).CountAsync(x => x.Type.Id == drankTypeId);
        }

        public PagedList<Drank> GetDrankenForDrankType(int drankTypeId, ResourceParameters resourceParameters)
        {
            var result = GetAllWithAllIncluded().Where(x => x.Type.Id == drankTypeId);

            result = FilterDrinks(result, resourceParameters.Query);

            result = SortDrinks(result, resourceParameters.SortBy, resourceParameters.SortOrder);

            var pagedList = PagedList<Drank>.Create(result,resourceParameters.PageNumber, resourceParameters.PageSize);

            return pagedList;
        }

        private IQueryable<Drank> FilterDrinks(IQueryable<Drank> dranken, string query)
        {
            if (!string.IsNullOrWhiteSpace(query))
            {
                dranken = dranken.Where(x => x.Naam.ToLowerInvariant().Trim()
                    .Contains(query.ToLowerInvariant().Trim()));
            }
            return dranken;
        }

        private IQueryable<Drank> SortDrinks(IQueryable<Drank> dranken, string sortBy, string sortOrder)
        {

            var sortString = sortBy + " " + sortOrder;

            if (!string.IsNullOrWhiteSpace(sortString))
            {
                return dranken.OrderBy(sortString);
            }
            return dranken;
        }

        private IQueryable<Drank> GetAllWithAllIncluded()
        {
            return _dranken.Include(x => x.Type).Include(x => x.Prijzen);
        }

        public async Task<IEnumerable<Prijs>> GetPricesForDrank(int drankId)
        {
           // var drink = await _dranken.Include(x => x.Prijzen).FirstOrDefaultAsync(x => x.Id == drankId);

           var prices = from drinks in _dranken
                        where drinks.Id == drankId
                        select drinks.Prijzen;

            var single = await prices.SingleAsync();

            return single;
        }
    }
}
