using System.Threading.Tasks;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;

namespace kangoeroes.leidingBeheer.Data.Repositories.Interfaces
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
