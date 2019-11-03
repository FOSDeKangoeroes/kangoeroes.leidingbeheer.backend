using System;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Models.Accounting
{
    public abstract class Transaction
    {
        public Guid Id { get; set; }
        
        public decimal Amount { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Description { get; set; }
    }
}