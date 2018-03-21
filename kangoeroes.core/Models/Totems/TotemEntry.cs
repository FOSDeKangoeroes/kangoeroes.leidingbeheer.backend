using System;
using System.Collections.Generic;

namespace kangoeroes.core.Models.Totems
{
    public class TotemEntry
    {
        public int Id { get; set; }
        
        public DateTime DatumGekregen { get; set; }
        
        public Leiding Leiding { get; set; }
        
        public Totem Totem { get; set; }
        
        public Adjectief Adjectief { get; set; }
        
        public TotemEntry Voorouder { get; set; }
        
        public List<TotemEntry> Afstammelingen { get; set; }
        
    }
}