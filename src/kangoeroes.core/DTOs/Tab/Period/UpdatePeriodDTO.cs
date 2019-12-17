using System;

namespace kangoeroes.core.DTOs.Tab.Period
{
    public class UpdatePeriodDTO
    {
        public string Name { get; set; }
        
        public DateTime? Start { get; set; }
        
        public DateTime? End { get; set; }
    }
}