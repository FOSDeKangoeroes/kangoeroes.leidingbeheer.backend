using System.Threading.Tasks;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models.Accounting;

namespace kangoeroes.webUI.Services
{
    public class AccountService: IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        
        public async Task<Account> CreateAccountAsync(int userId)
        {
            var account = new Account(AccountType.Tab) {OwnerId = userId};

            await _accountRepository.CreateAccountAsync(account);

           return account;
        }
    }
}