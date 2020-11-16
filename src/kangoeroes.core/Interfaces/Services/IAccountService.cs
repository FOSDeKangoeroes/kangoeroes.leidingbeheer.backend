using System.Threading.Tasks;
using kangoeroes.core.Models.Accounting;

namespace kangoeroes.core.Interfaces.Services
{
    public interface IAccountService
    {
        Task<Account> CreateAccountAsync(int userId);
    }
}