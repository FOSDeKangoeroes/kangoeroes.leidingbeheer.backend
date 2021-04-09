using System;
using System.Collections.Generic;
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
    private readonly DbSet<TotemEntry> _entries;

    public TotemRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
      _totems = dbContext.Totems;
      _entries = dbContext.TotemEntries;
    }

    public override PagedList<Totem> FindAll(ResourceParameters resourceParameters)
    {
      var result = GetAllWithAllIncluded().AsNoTracking();

      var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

      if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
        result = result.Where(x => x.Naam.ToLower().Contains(resourceParameters.Query.ToLower()));


      if (!string.IsNullOrWhiteSpace(sortString)) result = result.OrderBy(sortString);

      var pagedList = PagedList<Totem>.QueryAndCreate(result, resourceParameters.PageNumber, resourceParameters.PageSize);

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

    public Dictionary<int, int> GetCountOfEntriesForTotems()
    {
      var query = from entries in _entries
        group entries by entries.TotemId
        into g
        select new {g.Key, Count = g.Count()};
      var dict = query.ToDictionary(x => x.Key, y => y.Count);
      return dict;
    }

    public async Task<DateTime> GetEarliestReuseDateForTotem(int id)
    {
      var entries = _entries.Include(x => x.Leiding).Where(x => x.TotemId == id);

      entries = entries.OrderByDescending(x => x.ReuseDateTotem);

      var first = await entries.FirstOrDefaultAsync();
      return first.ReuseDateTotem;
    }
  }
}
