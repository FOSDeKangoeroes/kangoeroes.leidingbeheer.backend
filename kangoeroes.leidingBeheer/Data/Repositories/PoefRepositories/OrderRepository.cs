using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using kangoeroes.core.Models.Poef;
using kangoeroes.webUI.Data.Context;
using kangoeroes.webUI.Data.Repositories.PoefRepositories.Interfaces;
using kangoeroes.webUI.Helpers;
using kangoeroes.webUI.Helpers.ResourceParameters;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.webUI.Data.Repositories.PoefRepositories
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
      var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

      var result = GetAllWithAllIncluded();

      var orderParameters = (OrderResourceParameters) resourceParameters;

      if (orderParameters.Start.Year != 1)
      {
        result = result.Where(x => x.CreatedOn >= orderParameters.Start);
      }

      if (orderParameters.End.Year != 1)
      {
        result = result.Where(x => x.CreatedOn <= orderParameters.End);
      }

      if (!string.IsNullOrWhiteSpace(sortString)) result = result.OrderBy(sortString);

      var pagedList = PagedList<Order>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

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
