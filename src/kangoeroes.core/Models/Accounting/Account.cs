using System;
using System.Collections;
using System.Collections.Generic;

namespace kangoeroes.core.Models.Accounting
{
    public abstract class Account
    {
        public Guid Id { get; set; }
        
        public decimal Balance { get; private set; }
        
        public DateTime LastUpdated { get; private set; }
        
       // public ICollection<Transaction> Transactions { get; set; }
        
    }
}