using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using kangoeroes.core.Models.Poef;
using kangoeroes.leidingBeheer.Data.Context;
using kangoeroes.leidingBeheer.Data.Repositories.PoefRepositories.Interfaces;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.leidingBeheer.Data.Repositories.PoefRepositories
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
      var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

      var result = GetAllWithAllIncluded();


      if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
        result = result.Where(x => x.Naam.ToLowerInvariant().Trim()
          .Contains(resourceParameters.Query.ToLowerInvariant().Trim()));

      if (!string.IsNullOrWhiteSpace(sortString)) result = result.OrderBy(sortString);

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

    private IQueryable<Drank> GetAllWithAllIncluded()
    {
      return _dranken.Include(x => x.Type).Include(x => x.Prijzen);
    }
  }
}
