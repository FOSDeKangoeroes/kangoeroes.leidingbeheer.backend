using System.Collections;
using System.Collections.Generic;

namespace kangoeroes.core.Models.Accounting
{
    public class TabAccount: Account
    {
        public ICollection<TabTransaction> Transactions { get; set; }
    }
}