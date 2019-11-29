using System.Collections.Generic;

namespace kangoeroes.core.Models.Poef
{
    /// <summary>
    ///     Entiteit voor het weergeven van een type waaronder een drank valt.
    /// </summary>
    public class DrankType
    {
        /// <summary>
        ///     Unieke sleutel van het type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Weergavenaam van het type
        /// </summary>
        public string Naam { get; set; }
        
        /// <summary>
        /// Alle dranken onder het dranktype
        /// </summary>
        public List<Drank> Dranken { get; set; }
    }
}