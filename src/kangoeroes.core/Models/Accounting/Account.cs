using System;
using System.Collections.Generic;
using System.Linq;

namespace kangoeroes.core.Models.Accounting
{
    public class Account
    {

        public Account(AccountType accountType)
        {
            AccountType = accountType;
        }

        public Guid Id { get; set; }

        public AccountType AccountType { get; set; }

        public Leiding Owner { get; set; }
        public int OwnerId { get; set; }

        public decimal Balance { get; set; }

        public DateTime LastUpdated { get; set; }

        private readonly List<Transaction> _transactions = new List<Transaction>();

        public IEnumerable<Transaction> Transactions => _transactions.ToList();

        public void AddTransaction(Transaction transaction)
        {
            Balance += transaction.Amount;
            _transactions.Add(transaction);
            LastUpdated = DateTime.Now;

        }

    }
}