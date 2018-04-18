using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kangoeroes.core.Models.Totems
{
    public class TotemEntry
    {
 
        public int Id { get; set; }


        public DateTime DatumGegeven { get; set; }

        public Leiding Leiding { get; set; }

        public Totem Totem { get; set; }

        public Adjectief Adjectief { get; set; }

        public TotemEntry Voorouder { get; set; }

        public List<TotemEntry> Afstammelingen { get; set; }

        [NotMapped]
        public DateTime ReuseDateTotem => Leiding.DatumGestopt.Year == 1
            ? Leiding.DatumGestopt
            : Leiding.DatumGestopt.AddYears(Leiding.HasBeenLeiding ? 10 : 5);

        [NotMapped]
        public DateTime ReuseDateAdjectief =>
            Leiding.DatumGestopt.Year == 1 ? Leiding.DatumGestopt : Leiding.DatumGestopt.AddYears(5);



    }
}