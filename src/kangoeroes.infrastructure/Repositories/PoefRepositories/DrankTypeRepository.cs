﻿using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Models.Poef;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.infrastructure.Repositories.PoefRepositories
{
  /// <inheritdoc cref="IDrankTypeRepository" />
  public class DrankTypeRepository: BaseRepository<DrankType>, IDrankTypeRepository
  {
    private readonly DbSet<DrankType> _types;

    /// <summary>
    /// Maakt een nieuwe instantie van de repository aan
    /// </summary>
    /// <param name="dbContext">Huidige context van de database</param>
    public DrankTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
      _types = dbContext.DrankTypes;
    }


    /// <inheritdoc />
    public override PagedList<DrankType> FindAll(ResourceParameters resourceParameters)
    {
      var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

      var result = _types.AsQueryable();


      if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
        result = result.Where(x => x.Naam.ToLowerInvariant().Trim()
          .Contains(resourceParameters.Query.ToLowerInvariant().Trim()));

      if (!string.IsNullOrWhiteSpace(sortString)) result = result.OrderBy(sortString);

      var pagedList = PagedList<DrankType>.QueryAndCreate(result, resourceParameters.PageNumber, resourceParameters.PageSize);

      return pagedList;
    }

    /// <inheritdoc />
    public override Task<DrankType> FindByIdAsync(int id)
    {
      return _types.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<DrankType> FindTypeByNaam(string naam)
    {
      return _types.FirstOrDefaultAsync(x => EF.Functions.Like(x.Naam, naam));
    }

  }
}
