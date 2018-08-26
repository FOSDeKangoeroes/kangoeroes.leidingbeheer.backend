using System;
using System.Collections.Generic;

namespace kangoeroes.core.Models.Poef
{
    public class Order
    {
        public Order()
        {
            Orderlines = new List<Orderline>();
        }
        public int Id { get; set; }
        
        public Leiding OrderedBy { get; set; }
        
        public DateTime CreatedOn { get; set; }
        
        public List<Orderline> Orderlines { get; set; } 
    }
}