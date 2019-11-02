using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;

namespace kangoeroes.core.Interfaces.Repositories
{
  public interface IBaseRepository<T> where T : class
  {
    PagedList<T> FindAll(ResourceParameters resourceParameters);
    Task<T> FindByIdAsync(int id);
    Task AddAsync(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
  }
}
