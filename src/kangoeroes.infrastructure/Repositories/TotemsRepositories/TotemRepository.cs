using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Models.Totems;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.infrastructure.Repositories.TotemsRepositories
{
  public class TotemRepository : BaseRepository<Totem>, ITotemRepository
  {
    private readonly DbSet<Totem> _totems;

    public TotemRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
      _totems = dbContext.Totems;
    }

    public override PagedList<Totem> FindAll(ResourceParameters resourceParameters)
    {
      var result = GetAllWithAllIncluded().AsNoTracking();

      var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

      if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
        result = result.Where(x => x.Naam.ToLower().Contains(resourceParameters.Query.ToLower()));


      if (!string.IsNullOrWhiteSpace(sortString)) result = result.OrderBy(sortString);

      var pagedList = PagedList<Totem>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

      return pagedList;
    }

    public override Task<Totem> FindByIdAsync(int id)
    {
      return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<Totem> FindByNaamAsync(string naam)
    {
      return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Naam == naam);
    }

    private IQueryable<Totem> GetAllWithAllIncluded()
    {
      return _totems;
    }
  }
}
