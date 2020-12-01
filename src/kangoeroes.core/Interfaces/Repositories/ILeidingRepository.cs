using System.Threading.Tasks;
using kangoeroes.core.Models;

namespace kangoeroes.core.Interfaces.Repositories
{
  public interface ILeidingRepository : IBaseRepository<Leiding>
  {
    Task<Leiding> FindByEmailAsync(string userEmail);
  }
}
