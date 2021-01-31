using System.Threading.Tasks;
using kangoeroes.core.Models.Accounting;

namespace kangoeroes.core.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> FindAccountAsync(int leidingId, AccountType type);
        Task<Account> CreateAccountAsync(Account newAccount);
    }
}