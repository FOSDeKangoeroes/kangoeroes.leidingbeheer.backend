using System.Threading.Tasks;
using kangoeroes.leidingBeheer.Data.Context;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;
using kangoeroes.leidingBeheer.Helpers;

namespace kangoeroes.leidingBeheer.Data.Repositories
{
  public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    private readonly ApplicationDbContext _dbContext;

    protected BaseRepository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public abstract PagedList<T> FindAll(ResourceParameters resourceParameters);
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
