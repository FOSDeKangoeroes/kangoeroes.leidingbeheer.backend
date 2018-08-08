namespace kangoeroes.core.Models.Poef
{
    /// <summary>
    /// Entiteit voor het representeren van een drank.
    /// </summary>
    public class Drank
    {
        /// <summary>
        /// Unieke sleutel van een drank.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Weergavenaam van een drank.
        /// </summary>
        public string Naam { get; set; }
        /// <summary>
        /// Bestandslocatie van een afbeelding die de drank weergeeft.
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Aanduiding of de drank al dan niet beschikbaar is.
        /// </summary>
        public bool InStock { get; set; }
        /// <summary>
        /// Type waaronder de drank zich bevindt.
        /// </summary>
        public DrankType Type { get; set; }
    }
}