using System;

namespace kangoeroes.core.Models
{
    /// <summary>
    /// Basisklasse voor het modelleren van een leiding. Dit kan echter eender wie zijn die een totem heeft, de poef kan gebruiken of schulden/vorderingen heeft.
    /// </summary>
    public class Leiding
    {
        public int Id { get; set; }
        
        public string Auth0Id { get; set; }
        
        public string Naam { get; set; }
        
        public string Voornaam { get; set; }
        
        public string Email { get; set; }
        
        public DateTime LeidingSinds { get; set; }
        
        public DateTime DatumGestopt { get; set; }
        
        public Tak Tak { get; set; }


    }
}