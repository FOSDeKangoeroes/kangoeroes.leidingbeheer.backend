using System.Collections;
using System.Collections.Generic;

namespace kangoeroes.core.Models.Accounting
{
    public class DebtAccount: Account
    {
        public ICollection<DebtTransaction> Transactions { get; set; }
    }
}