using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace kangoeroes.core.Models
{
    /// <summary>
    /// Basisklasse voor het modelleren van een leiding. Dit kan echter eender wie zijn die een totem heeft, de poef kan gebruiken of schulden/vorderingen heeft.
    /// </summary>
    public class Leiding
    {
        /// <summary>
        /// Unieke sleutel van de entiteit.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Unieke sleutel van het gebruikersaccount waaraan de entiteit gekoppeld is.
        /// </summary>
        public string Auth0Id { get; set; }
        
        /// <summary>
        /// Familienaam van de persoon.
        /// </summary>
        public string Naam { get; set; }
        
        /// <summary>
        /// Voornaam van de persoon.
        /// </summary>
        public string Voornaam { get; set; }
        
        /// <summary>
        /// Emailadres van de persoon.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Datum waarop de persoon in de leiding kwam.
        /// </summary>
        public DateTime LeidingSinds { get; set; }
         
        /// <summary>
        /// Datum waarop de persoon stopte met leiding zijn.
        /// </summary>
        public DateTime DatumGestopt { get; set; }
        
        
        /// <summary>
        /// Tak waartoe de persoon behoort.
        /// </summary>
        public Tak Tak { get; set; }

        /// <summary>
        /// Berekende property die aangeeft of een persoon leiding is geweest.
        /// </summary>
        [NotMapped]
        public bool HasBeenLeiding => DatumGestopt > LeidingSinds;

    }
}