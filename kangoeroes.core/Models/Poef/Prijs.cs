using System;

namespace kangoeroes.core.Models.Poef
{
    /// <summary>
    /// Entiteit die een prjs weergeeft
    /// </summary>
    public class Prijs
    {
        /// <summary>
        /// Private constructor om gebruik van de factory method te verplichten
        /// </summary>
        private Prijs()
        {
            
        }
        /// <summary>
        /// Unieke sleutel 
        /// </summary>
        public int Id {get;set;}
        
        /// <summary>
        /// Datum en tijd waarop de prijs werd aangemaakt
        /// </summary>
        public DateTime CreatedOn { get; set; }
        
        /// <summary>
        /// Waarde van de prijs (in euro)
        /// </summary>
        public decimal Waarde { get; set; }
        
        /// <summary>
        /// Vreemde sleutel die wijst naar de toegewezen drank.
        /// </summary>
        public Drank Drank { get; set; }

        /// <summary>
        /// Factory method om een nieuwe prijs te creeren met een gegeven waarde
        /// </summary>
        /// <param name="waarde">Waarde voor de prijs</param>
        /// <returns>Nieuwe entiteit van prijs</returns>
        public static Prijs Create(decimal waarde)
        {
            return new Prijs()
            {
                CreatedOn = DateTime.Now.ToLocalTime(),
                Waarde = waarde
            };
        }
        
        
    }
}