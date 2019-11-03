using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using kangoeroes.core.Models.Accounting;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Models
{
    /// <summary>
    ///     Basisklasse voor het modelleren van een leiding. Dit kan echter eender wie zijn die een totem heeft, de poef kan
    ///     gebruiken of schulden/vorderingen heeft.
    /// </summary>
    public class Leiding
    {
        /// <summary>
        ///     Unieke sleutel van de entiteit.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Familienaam van de persoon.
        /// </summary>
        public string Naam { get; set; }

        /// <summary>
        ///     Voornaam van de persoon.
        /// </summary>
        public string Voornaam { get; set; }

        /// <summary>
        ///     Emailadres van de persoon.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Datum waarop de persoon in de leiding kwam.
        /// </summary>
        public DateTime LeidingSinds { get; set; }

        /// <summary>
        ///     Datum waarop de persoon stopte met leiding zijn.
        /// </summary>
        public DateTime DatumGestopt { get; set; }


        /// <summary>
        ///     Tak waartoe de persoon behoort.
        /// </summary>
        public Tak Tak { get; set; }
        
        /// <summary>
        /// Alle consumpties die de persoon ooit heeft gedronken
        /// </summary>
        public List<Orderline> Consumpties { get; set; }
        
        /// <summary>
        /// Alle orders die de persoon heeft geplaatst
        /// </summary>
        public List<Order> Orders { get; set; }
        
        public DebtAccount DebtAccount { get; set; }
        
        public TabAccount TabAccount { get; set; }

        /// <summary>
        ///     Berekende property die aangeeft of een persoon leiding is geweest.
        /// </summary>
        [NotMapped]
        public bool HasBeenLeiding => DatumGestopt > LeidingSinds;
    }
}