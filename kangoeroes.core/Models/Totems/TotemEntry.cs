using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kangoeroes.core.Models.Totems
{
    /// <summary>
    /// Entiteit die een getotemiseerd persoon voorstelt. 
    /// </summary>
    public class TotemEntry
    {
 
        /// <summary>
        /// Unieke sleutel van de getotemiseerde
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Datum waarop de totemisatie werd uitgevoerd.
        /// </summary>
        public DateTime DatumGegeven { get; set; }

        /// <summary>
        /// Persoon die getotemiseerd werd.
        /// </summary>
        public Leiding Leiding { get; set; }

        /// <summary>
        /// Totemdier van de getotemiseerde.
        /// </summary>
        public Totem Totem { get; set; }

        /// <summary>
        /// Adjectief van de getotemiseerde.
        /// </summary>
        public Adjectief Adjectief { get; set; }

        /// <summary>
        /// Voorouder van de getotemiseerde.
        /// </summary>
        public TotemEntry Voorouder { get; set; }

        /// <summary>
        /// Alle afstammelingen van de getotemiseerde
        /// </summary>
        public List<TotemEntry> Afstammelingen { get; set; }

        /// <summary>
        /// Berekende property die aangeeft wanneer het totemdier van deze getotemiseerde kan hergebruikt worden.
        /// </summary>
        [NotMapped]
        public DateTime ReuseDateTotem => Leiding.DatumGestopt.Year == 1
            ? Leiding.DatumGestopt
            : Leiding.DatumGestopt.AddYears(Leiding.HasBeenLeiding ? 10 : 5);

        /// <summary>
        /// Berekende property die aangeeft wanneer het adjectief van deze getotemiseerde kan hergebruikt worden.
        /// </summary>
        [NotMapped]
        public DateTime ReuseDateAdjectief =>
            Leiding.DatumGestopt.Year == 1 ? Leiding.DatumGestopt : Leiding.DatumGestopt.AddYears(5);



    }
}