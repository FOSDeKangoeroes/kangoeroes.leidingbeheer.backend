using System;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Models.Accounting
{
    public class Transaction
    {
        public Transaction(decimal amount, string description)
        {
            Amount = amount;
            Description = description;
            Date = DateTime.Now;
        }
        public Guid Id { get; set; }
        
        public decimal Amount { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Description { get; set; }

    }
}