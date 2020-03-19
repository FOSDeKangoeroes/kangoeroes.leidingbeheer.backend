using System;

namespace kangoeroes.core.Models.Totems
{
    /// <summary>
    ///     Entiteit voor het representeren van een dier dat kan toegekend worden aan een getotemiseerde.
    /// </summary>
    public class Totem
    {
        /// <summary>
        ///     Maakt een nieuwe entiteit aan. CreatedOn wordt direct ingesteld op DateTime.Now.
        /// </summary>
        public Totem()
        {
            CreatedOn = DateTime.Now;
        }

        /// <summary>
        ///     Unieke sleutel van de entiteit.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Naam van het dier.
        /// </summary>
        public string Naam { get; set; }

        /// <summary>
        ///     Datum en tijd waarop de entiteit werd aangemaakt.
        /// </summary>
        public DateTime CreatedOn { get; set; }
        
    }
}