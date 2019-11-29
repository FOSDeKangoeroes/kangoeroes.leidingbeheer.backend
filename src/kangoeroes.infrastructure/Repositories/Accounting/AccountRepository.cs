using System;
using System.Linq;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Models.Accounting;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.infrastructure.Repositories.Accounting
{
    public class AccountRepository: IAccountRepository
    {
        private ApplicationDbContext _dbContext;
        private DbSet<Account> _accounts;
        public AccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _accounts = _dbContext.Accounts;
        }

        public async Task<Account> FindAccountAsync(int leidingId, AccountType type)
        {
            return await _accounts.Where(x => x.OwnerId == leidingId && x.AccountType == type).FirstOrDefaultAsync();
        }
    }
}