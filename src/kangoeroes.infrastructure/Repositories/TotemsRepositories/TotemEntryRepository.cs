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
  public class TotemEntryRepository : BaseRepository<TotemEntry>, ITotemEntryRepository
  {
    private readonly DbSet<TotemEntry> _totemEntries;

    public TotemEntryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
      _totemEntries = dbContext.TotemEntries;
    }

    public override PagedList<TotemEntry> FindAll(ResourceParameters resourceParameters)
    {
      var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

      var collectionBeforePaging = GetAllWithAllIncluded();

      if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
      {
        var fullQuery = resourceParameters.Query.ToLowerInvariant().Trim();

        var searchTerms = fullQuery.Split(' ');

        foreach (var query in searchTerms)
        {
          collectionBeforePaging = collectionBeforePaging.Where(x =>
            x.Totem.Naam.ToLower().Contains(query)
            | x.Adjectief.Naam.ToLower().Contains(query)
            | x.Leiding.Voornaam.ToLower().Contains(query)
            | x.Leiding.Naam.ToLower().Contains(query));
        }

      }



      if (!string.IsNullOrWhiteSpace(sortString)) collectionBeforePaging = collectionBeforePaging.OrderBy(sortString);

      var pagedList = PagedList<TotemEntry>.Create(collectionBeforePaging, resourceParameters.PageNumber,
        resourceParameters.PageSize);

      return pagedList;
    }

    public override Task<TotemEntry> FindByIdAsync(int id)
    {
      return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<TotemEntry> FindByLeidingIdAsync(int leidingId)
    {
      return _totemEntries.Include(x => x.Leiding).FirstOrDefaultAsync(x => x.Leiding.Id == leidingId);
    }


    public IEnumerable<TotemEntry> GetDescendants(int totemEntryId)
    {
      return GetAllWithAllIncluded().Where(x => x.Voorouder.Id == totemEntryId);
    }

    public IEnumerable<TotemEntry> GetFamilyTree()
    {
      return _totemEntries.Include(x => x.Adjectief).Include(x => x.Totem).Include(x => x.Voorouder);
    }

    private IQueryable<TotemEntry> GetAllWithAllIncluded()
    {
      return _totemEntries.Include(x => x.Adjectief).Include(x => x.Leiding).Include(x => x.Totem)
        .Include(x => x.Voorouder).ThenInclude(x => x.Adjectief).Include(x => x.Voorouder).ThenInclude(x => x.Totem);
    }
  }
}
