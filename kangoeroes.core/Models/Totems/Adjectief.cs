using System;

namespace kangoeroes.core.Models.Totems
{
    /// <summary>
    /// Entiteit voor het representeren van een adjectief dat kan toegekend worden aan een getotemiseerde.
    /// </summary>
    public class Adjectief
    {
        /// <summary>
        /// Unieke sleutel van de entiteit
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// De naam van het adjectief.
        /// </summary>
        public string Naam { get; set; }
        
        /// <summary>
        /// Datum waarop het adjectief werd aangemaakt.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Maakt een nieuwe instantie van het adjectief. CreatedOn wordt direct ingesteld op DateTime.Now.
        /// </summary>
        public Adjectief()
        {
            CreatedOn = DateTime.Now;
        }
    }
}