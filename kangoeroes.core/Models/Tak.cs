using System.Collections;
using System.Collections.Generic;

namespace kangoeroes.core.Models
{
    public class Tak
    {
        public int Id { get; set; }
        
        public string Naam { get; set; }
        
        public int Volgorde { get; set; }

        public ICollection<Leiding> Leiding { get; set; }


    }
}