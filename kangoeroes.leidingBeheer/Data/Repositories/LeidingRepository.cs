using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using kangoeroes.core.Models;
using kangoeroes.leidingBeheer.Data.Context;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.leidingBeheer.Data.Repositories
{
  public class LeidingRepository : BaseRepository<Leiding>, ILeidingRepository
  {
    private readonly DbSet<Leiding> _leiding;

    public LeidingRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
      _leiding = dbContext.Leiding;
    }

    public override PagedList<Leiding> FindAll(ResourceParameters resourceParameters)
    {
      var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

      var result = GetAllWithAllIncluded();


      if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
        result = result.Where(x => (x.Voornaam + " " + x.Naam).Contains(resourceParameters.Query) |
                                   x.Email.Contains(resourceParameters.Query));

      if (!string.IsNullOrWhiteSpace(sortString)) result = result.OrderBy(sortString);

      if (resourceParameters is LeidingResourceParameters leidingParameters && leidingParameters.Tak != 0)
      {
        result = result.Where(x => x.Tak.Id == leidingParameters.Tak);
      }

      var pagedList = PagedList<Leiding>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

      return pagedList;
    }

    public override Task<Leiding> FindByIdAsync(int id)
    {
      return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Id == id);
    }

    //Helper method to get all leiding with all dependencies already included
    private IQueryable<Leiding> GetAllWithAllIncluded()
    {
      return _leiding.Include(x => x.Tak);
    }
  }
}
