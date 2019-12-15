using System.Linq.Dynamic.Core;
using System.Linq;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Models.Poef;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.infrastructure.Repositories.PoefRepositories
{
  public class OrderlineRepository: BaseRepository<Orderline>, IOrderlineRepository
  {
    private readonly DbSet<Orderline> _orderlines;

    public OrderlineRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
      _orderlines = dbContext.Orderlines;
    }

    public override PagedList<Orderline> FindAll(ResourceParameters resourceParameters)
    {
      IQueryable<Orderline> result = _orderlines.Include(x => x.Order).Include(x => x.Drank).Include(x => x.OrderedFor);
      var sortString = resourceParameters.GetFullSortString();

      var orderlineParameters = (OrderlineResourceParameters) resourceParameters;

      if (orderlineParameters.Start.Year != 1)
      {
        result = result.Where(x => x.Order.CreatedOn.Date >= orderlineParameters.Start);
      }

      if (orderlineParameters.Start.Year != 1)
      {
        result = result.Where(x => x.Order.CreatedOn.Date <= orderlineParameters.End);
      }

      if (!string.IsNullOrWhiteSpace(sortString))
      {
        result = result.OrderBy(sortString);
      }

      var pagedList = PagedList<Orderline>.Create(result, orderlineParameters.PageNumber, orderlineParameters.PageSize);

      return pagedList;
    }

    public override Task<Orderline> FindByIdAsync(int id)
    {
      return _orderlines.FirstOrDefaultAsync(x => x.Id == id);
    }
  }
}
