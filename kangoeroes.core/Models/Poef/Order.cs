using System;
using System.Collections.Generic;

namespace kangoeroes.core.Models.Poef
{
    public class Order
    {
        /// <summary>
        /// Private constructor zodat er enkel een order kan aangemaakt worden adhv de factory method
        /// </summary>
        private Order()
        {
            Orderlines = new List<Orderline>();
        }
        public int Id { get; set; }
        
        public Leiding OrderedBy { get; set; }
        
        public DateTime CreatedOn { get; set; }
        
        public List<Orderline> Orderlines { get; set; }

        public static Order Create(Leiding orderedBy, List<Orderline> lines)
        {
            return new Order()
            {
                OrderedBy = orderedBy,
                CreatedOn = DateTime.Now.ToLocalTime()
            };
        }
    }
}