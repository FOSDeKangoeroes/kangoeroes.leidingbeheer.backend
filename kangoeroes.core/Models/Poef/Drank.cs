using System.Collections.Generic;
using System.Linq;

namespace kangoeroes.core.Models.Poef
{
    /// <summary>
    ///     Entiteit voor het representeren van een drank.
    /// </summary>
    public class Drank
    {
        /// <summary>
        /// Maakt een nieuwe entiteit. Hierbij wordt een lege lijst van prijzen aangemaakt.
        /// </summary>
        public Drank()
        {
            Prijzen = new List<Prijs>();
        }
        
        /// <summary>
        ///     Unieke sleutel van een drank.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Weergavenaam van een drank.
        /// </summary>
        public string Naam { get; set; }

        /// <summary>
        ///     Bestandslocatie van een afbeelding die de drank weergeeft.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        ///     Aanduiding of de drank al dan niet beschikbaar is.
        /// </summary>
        public bool InStock { get; set; }

        /// <summary>
        ///     Type waaronder de drank zich bevindt.
        /// </summary>
        public DrankType Type { get; set; }
        
        /// <summary>
        /// Lijst van alle prijzen die die drank heeft (gehad).
        /// </summary>
        public List<Prijs> Prijzen { get; set; }

        /// <summary>
        /// Berekende property die de prijs teruggeeft die momenteel actief is.
        /// </summary>
        public Prijs CurrentPrijs
        {
            get { return Prijzen.OrderByDescending(x => x.CreatedOn).FirstOrDefault(); }
        }

/// <summary>
/// Probeer een nieuwe prijs toe te voegen indien de prijs verschillend is van de huidige prijs.
/// </summary>
/// <param name="newPrijs">Nieuw toe te voegen prijs</param>

        public void TryAddNewPrijs(decimal newPrijs)
        {
            //Nieuwe prijs enkel toevoegen wanneer er geen huidige prijs is of wanneer de huidige prijs verschillend is van de nieuwe.
            if (CurrentPrijs == null || newPrijs != CurrentPrijs.Waarde)
            {
                var newPrijsEntity = Prijs.Create(newPrijs);
                Prijzen.Add(newPrijsEntity);
            }
        }
    }
}