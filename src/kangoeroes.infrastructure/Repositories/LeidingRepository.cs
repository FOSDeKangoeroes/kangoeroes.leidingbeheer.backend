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

      var result = GetAllWithAllIncluded().AsNoTracking();


      if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
        result = result.Where(x => (x.Voornaam.ToLower() + " " + x.Naam.ToLower()).Contains(resourceParameters.Query.ToLower()) ||
                                   x.Email.ToLower().Contains(resourceParameters.Query));

      if (!string.IsNullOrWhiteSpace(sortString)) result = result.OrderBy(sortString);

      if (resourceParameters is LeidingResourceParameters leidingParameters)
      {

        if (leidingParameters.Tak != 0)
        {
           result = result.Where(x => x.Tak.Id == leidingParameters.Tak);
        }

        if (leidingParameters.Tab)
        {
          result = result.Where(x => x.Tak != null &&  x.Tak.TabIsAllowed);
        }
        
       
      }


      var pagedList = PagedList<Leiding>.QueryAndCreate(result, resourceParameters.PageNumber, resourceParameters.PageSize);

      return pagedList;
    }

    public override Task<Leiding> FindByIdAsync(int id)
    {
      return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<Leiding> FindByEmailAsync(string userEmail)
    {
      return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Email == userEmail);
    }

    //Helper method to get all leiding with all dependencies already included
    private IQueryable<Leiding> GetAllWithAllIncluded()
    {
      return _leiding.Include(x => x.Tak).Include(x => x.Accounts);
    }
  }
}
