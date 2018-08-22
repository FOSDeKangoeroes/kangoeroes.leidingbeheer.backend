﻿using System.Threading.Tasks;
using kangoeroes.leidingBeheer.Data.Context;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;

namespace kangoeroes.leidingBeheer.Data.Repositories
{
  public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    private readonly ApplicationDbContext _dbContext;

    protected BaseRepository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    /// <summary>
    /// Geeft een gepagineerde lijst terug van alle entiteiten T, rekening houdend met de gegeven parameters
    /// </summary>
    /// <param name="resourceParameters">Parameters voor pagineren, zoeken en sorteren</param>
    /// <returns>Gepagineerde lijst van T</returns>
    public abstract PagedList<T> FindAll(ResourceParameters resourceParameters);

    /// <summary>
    /// Geeft een entiteit T terug met de gevraagde unieke sleutel.
    /// </summary>
    /// <param name="id">Unieke sleutel van de gevraagde entiteit</param>
    /// <returns></returns>
    public abstract Task<T> FindByIdAsync(int id);

    public Task AddAsync(T entity)
    {
      return _dbContext.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
      _dbContext.Set<T>().Remove(entity);
    }

    public Task SaveChangesAsync()
    {
      return _dbContext.SaveChangesAsync();
    }
  }
}
