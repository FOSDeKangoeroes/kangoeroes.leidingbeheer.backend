using System;

namespace kangoeroes.core.Models.Accounting
{
    public class DebtTransaction : Transaction
    {
        public DebtTransaction(decimal amount)
        {
            Amount = amount;
            Date = DateTime.Now.ToLocalTime();
        }
    }
}