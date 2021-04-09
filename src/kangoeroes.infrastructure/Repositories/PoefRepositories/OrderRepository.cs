using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Models.Poef;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.infrastructure.Repositories.PoefRepositories
{
  /// <inheritdoc cref="IOrderRepository" />
  public class OrderRepository: BaseRepository<Order>, IOrderRepository
  {

    private readonly DbSet<Order> _orders;

    /// <summary>
    /// Maakt een nieuwe instantie van de OrderRepository klasse aan.
    /// </summary>
    /// <param name="dbContext">Huidige database context</param>
    public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
      _orders = dbContext.Orders;
    }


    /// <inheritdoc />
    public override PagedList<Order> FindAll(ResourceParameters resourceParameters)
    {
      var sortString = resourceParameters.GetFullSortString();

      var result = GetAllWithAllIncluded();

      var orderParameters = (OrderResourceParameters) resourceParameters;

      if (orderParameters.Start.Year != 1)
      {
        result = result.Where(x => x.CreatedOn.Date >= orderParameters.Start);
      }

      if (orderParameters.End.Year != 1)
      {
        result = result.Where(x => x.CreatedOn.Date <= orderParameters.End);
      }

      if (!string.IsNullOrWhiteSpace(sortString)) result = result.OrderBy(sortString);

      var pagedList = PagedList<Order>.QueryAndCreate(result, resourceParameters.PageNumber, resourceParameters.PageSize);

      return pagedList;
    }

    /// <inheritdoc />
    public override Task<Order> FindByIdAsync(int id)
    {
      return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Id == id);
    }


    private IQueryable<Order> GetAllWithAllIncluded()
    {
      return _orders
        .Include(x => x.Orderlines).ThenInclude(x => x.OrderedFor)
        .Include(x => x.Orderlines)
        .ThenInclude(x => x.Drank)
        .Include(x => x.OrderedBy);
    }
  }
}
