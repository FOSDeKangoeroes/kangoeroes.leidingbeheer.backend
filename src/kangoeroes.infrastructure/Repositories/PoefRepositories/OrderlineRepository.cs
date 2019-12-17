using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Models;
using kangoeroes.core.Models.Poef;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.infrastructure.Repositories.PoefRepositories
{
    public class OrderlineRepository : BaseRepository<Orderline>, IOrderlineRepository
    {
        private readonly DbSet<Orderline> _orderlines;
        private readonly ApplicationDbContext _dbContext;

        public OrderlineRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _orderlines = dbContext.Orderlines;
            _dbContext = dbContext;
        }

        public override PagedList<Orderline> FindAll(ResourceParameters resourceParameters)
        {
            IQueryable<Orderline> result = _orderlines.Include(x => x.Order).Include(x => x.Drank)
                .Include(x => x.OrderedFor);
            var sortString = resourceParameters.GetFullSortString();

            var orderlineParameters = (OrderlineResourceParameters) resourceParameters;

            result = FilterOrderlinesByDates(orderlineParameters.Start, orderlineParameters.End, result);

            if (!string.IsNullOrWhiteSpace(sortString))
            {
                result = result.OrderBy(sortString);
            }

            var pagedList =
                PagedList<Orderline>.Create(result, orderlineParameters.PageNumber, orderlineParameters.PageSize);

            return pagedList;
        }

        public override Task<Orderline> FindByIdAsync(int id)
        {
            return _orderlines.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<PersonOrderlineSummary> GetPersonSummary(OrderlineResourceParameters parameters)
        {
            var result = FilterOrderlinesByDates(parameters.Start, parameters.End, _orderlines.Include(x => x.OrderedFor));

            //This is evaluated on the client. Wait for EF Core to have proper support for GroupBy.
            var summary = result.ToList().GroupBy(x => x.OrderedFor).Select(x => (
               
                
                new PersonOrderlineSummary
            {
                AmountOfConsumptions = x.Sum(x => x.Quantity),
                TotalCost = x.Sum(x => x.Quantity * x.DrinkPrice),
                LeaderId = x.Key.Id,
                Leader = $"{x.Key.Voornaam} {x.Key.Naam}"
            })
                );
            return summary;
        }

        private IQueryable<Orderline> FilterOrderlinesByDates(DateTime start, DateTime end,
            IQueryable<Orderline> result)
        {
            var test = nameof(Order.CreatedOn);
            if (start.Year != 1)
            {
                result = result.Where(x => x.Order.CreatedOn.Date >= start);
            }

            if (end.Year != 1)
            {
                result = result.Where(x => x.Order.CreatedOn.Date <= end);
            }

            return result;
        }
        
    }
}