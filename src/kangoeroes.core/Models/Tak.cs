using System.Collections.Generic;

namespace kangoeroes.core.Models
{
    /// <summary>
    ///     Entitiet om groepen van personen te modelleren naar het tak principe van de eenheid.
    /// </summary>
    public class Tak
    {
        /// <summary>
        ///     Maakt een nieuwe instantie van een tak aan.
        /// </summary>
        public Tak()
        {
            Leiding = new List<Leiding>();
        }

        /// <summary>
        ///     Unieke sleutel van de tak.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Naam van de tak.
        /// </summary>
        public string Naam { get; set; }

        /// <summary>
        ///     Volgorde waarin de tak zich bevindt. Een tak met een laag nummer zal in een lijst eerder voorkomen dan een tak met
        ///     een hoog nummer.
        /// </summary>
        public int Volgorde { get; set; }
        
        /// <summary>
        /// Indicates whether people in this section have the ability to use the tab system or not.
        /// </summary>
        public bool TabIsAllowed { get; set; }

        /// <summary>
        ///     Alle leiding die zich in de tak bevindt.
        /// </summary>
        public ICollection<Leiding> Leiding { get; set; }
    }
}