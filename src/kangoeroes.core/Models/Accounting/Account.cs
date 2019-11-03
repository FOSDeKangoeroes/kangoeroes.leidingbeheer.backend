using System;

namespace kangoeroes.core.Models.Accounting
{
    public abstract class Account
    {
        public Guid Id { get; set; }
        
        public decimal Balance { get; set; }
        
        public DateTime LastUpdated { get; set; }
    }
}