﻿using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Models;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.infrastructure.Repositories
{
  public class TakRepository : BaseRepository<Tak>, ITakRepository
  {
    private readonly DbSet<Tak> _takken;


    public TakRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
      _takken = dbContext.Takken;
    }


    public override PagedList<Tak> FindAll(ResourceParameters resourceParameters)
    {
      var result = GetAllWithAllIncluded().AsNoTracking();

      var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

      if (resourceParameters is TakResourceParameters takResourceParameters && takResourceParameters.TabIsAllowed)
      {
        result = result.Where(x => x.TabIsAllowed);
      }

      if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
        result = result.Where(x => x.Naam.Contains(resourceParameters.Query));


      if (!string.IsNullOrWhiteSpace(sortString)) result = result.OrderBy(sortString);

      var pagedList = PagedList<Tak>.QueryAndCreate(result, resourceParameters.PageNumber, resourceParameters.PageSize);

      return pagedList;
    }

    public override Task<Tak> FindByIdAsync(int id)
    {
      return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Id == id);
    }

    public Tak FindByNaam(string naam)
    {
      return GetAllWithAllIncluded().FirstOrDefault(x => x.Naam == naam);
    }

    private IQueryable<Tak> GetAllWithAllIncluded()
    {
      return _takken.Include(x => x.Leiding);
    }
  }
}
