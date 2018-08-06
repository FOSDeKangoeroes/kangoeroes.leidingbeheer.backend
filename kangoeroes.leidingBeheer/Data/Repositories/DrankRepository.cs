using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.Data.Context;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;
using kangoeroes.leidingBeheer.Helpers;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.leidingBeheer.Data.Repositories
{
  public class DrankRepository: BaseRepository<Drank>, IDrankRepository
  {
    private readonly DbSet<Drank> _dranken;
    public DrankRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
      _dranken = dbContext.Dranken;
    }

    private IQueryable<Drank> GetAllWithAllIncluded()
    {
      return _dranken.Include(x => x.Type);
    }

    public override PagedList<Drank> FindAll(ResourceParameters resourceParameters)
    {
      var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

      var result = GetAllWithAllIncluded();


      if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
      {
        result = result.Where(x => x.Naam.ToLowerInvariant().Trim()
          .Contains(resourceParameters.Query.ToLowerInvariant().Trim()));

      }

      if (!string.IsNullOrWhiteSpace(sortString))
      {
        result = result.OrderBy(sortString);
      }

      var pagedList = PagedList<Drank>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

      return pagedList;
    }

    public override Task<Drank> FindByIdAsync(int id)
    {
      return _dranken.FirstOrDefaultAsync(x => x.Id == id);
    }
  }
}
