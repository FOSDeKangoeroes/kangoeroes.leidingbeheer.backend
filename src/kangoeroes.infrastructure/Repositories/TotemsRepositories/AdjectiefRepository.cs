﻿using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Models.Totems;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.infrastructure.Repositories.TotemsRepositories
{
  public class AdjectiefRepository : BaseRepository<Adjectief>, IAdjectiefRepository
  {
    private readonly DbSet<Adjectief> _adjectieven;
    private readonly ApplicationDbContext _dbContext;

    public AdjectiefRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
      _dbContext = dbContext;
      _adjectieven = dbContext.Adjectieven;
    }

    public override PagedList<Adjectief> FindAll(ResourceParameters resourceParameters)
    {
      var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

      var result = _adjectieven.AsQueryable().AsNoTracking();


      if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
        result = result.Where(x => x.Naam.ToLower()
          .Contains(resourceParameters.Query.ToLower()));

      if (!string.IsNullOrWhiteSpace(sortString)) result = result.OrderBy(sortString);

      var pagedList = PagedList<Adjectief>.QueryAndCreate(result, resourceParameters.PageNumber, resourceParameters.PageSize);

      return pagedList;
    }

    public override Task<Adjectief> FindByIdAsync(int id)
    {
      return _adjectieven.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<Adjectief> FindByNaamAsync(string naam)
    {
      return _adjectieven.FirstOrDefaultAsync(x => x.Naam == naam);
    }
  }
}
