using System.Collections;
using System.Collections.Generic;

namespace kangoeroes.core.Models.Accounting
{
    public class DebtAccount: Account
    {
        public DebtAccount()
        {
            Transactions = new List<DebtTransaction>();
        }
        public DebtAccount(decimal startBalance)
        {
            Transactions = new List<DebtTransaction>();
            var transaction = new DebtTransaction(startBalance);
            Transactions.Add(transaction);
            
        }
        public ICollection<DebtTransaction> Transactions { get; set; }
    }
}