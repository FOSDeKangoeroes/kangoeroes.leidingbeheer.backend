using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
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
      
      IQueryable<TotemEntry> collectionBeforePaging = GetAllWithAllIncluded().AsNoTracking();

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

      //These values are calculated properties and can't be translated to SQL, we have to override our dynamic sorting. This feels very hacky though :D
      if (resourceParameters.SortBy == "reuseDateTotem" || resourceParameters.SortBy == "reuseDateAdjectief")
      {
       
        var property = typeof(TotemEntry).GetProperty(resourceParameters.SortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        
        var newCollection = collectionBeforePaging.AsEnumerable<TotemEntry>();
        
        switch (resourceParameters.SortOrder)
        {
          case "asc": newCollection = newCollection.AsEnumerable().OrderBy(x => property.GetValue(x));
            break;
          case "desc": newCollection = newCollection.AsEnumerable().OrderByDescending(x => property.GetValue(x));
            break;
        }
        
        return PagedList<TotemEntry>.Create(newCollection, resourceParameters.PageNumber, resourceParameters.PageSize);
     
      }
      
      
      //We want to sort on a database, property, back to normal.
      if (!string.IsNullOrWhiteSpace(resourceParameters.GetFullSortString()))
      {
        collectionBeforePaging = collectionBeforePaging.OrderBy(resourceParameters.GetFullSortString());
      }
      return PagedList<TotemEntry>.Create(collectionBeforePaging, resourceParameters.PageNumber, resourceParameters.PageSize);
      
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
