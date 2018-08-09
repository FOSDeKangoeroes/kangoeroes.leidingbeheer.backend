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

        /// <summary>
        ///     Geeft terug of een meegegeven naam overeenkomt met de naam van de entiteit.
        /// </summary>
        /// <param name="naam">String die gematcht moet worden aan de naam van de entiteit.</param>
        /// <returns>Boolean die aangeeft of de meegegeven waarde gelijk is aan de naam van de entiteit.</returns>
        public bool Matches(string naam)
        {
            return Naam.Trim().ToLowerInvariant().Equals(naam.Trim().ToLowerInvariant());
        }
    }
}