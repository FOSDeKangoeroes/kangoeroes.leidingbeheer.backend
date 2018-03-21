using System;

namespace kangoeroes.core.Models.Totems
{
    public class Totem
    {
        public int Id { get; set; }
        
        public string Naam { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public Totem()
        {
            CreatedOn = DateTime.Now;
        }

        public bool Matches(string naam)
        {
            return Naam.Trim().ToLowerInvariant().Equals(naam.Trim().ToLowerInvariant());
        }
    }
}