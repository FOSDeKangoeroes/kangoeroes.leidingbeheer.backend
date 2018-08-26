namespace kangoeroes.core.Models.Poef
{
    /// <summary>
    /// Stelt een onderdeel van een bestelling voor. Een lijn van een bestelling stelt 1 gedronken consumptie voor.
    /// </summary>
    public class Orderline
    {
        /// <summary>
        /// Private constructor zodat er niet rechtstreeks instanties van een ordeline kunnen gemaakt worden.
        /// </summary>
        private Orderline()
        {
            
        }
        /// <summary>
        /// Unieke sleutel van de lijn
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gedronken consumptie
        /// </summary>
        public Drank Drank { get; set; }
        
        /// <summary>
        /// Persoon die de consumptie gedronken heeft.
        /// </summary>
        public Leiding OrderedFor { get; set; }
        
        /// <summary>
        /// Bestelling waartoe de lijn behoort
        /// </summary>
        public Order Order { get; set; }
        
        /// <summary>
        /// Prijs die betaald is voor de consumptie.
        /// Wordt hier opgeslaan zodat er niet steeds een query moet uitgevoerd worden via
        /// Drank -> Prijs om de actieve prijs tijdens de bestelling te zoeken.
        /// </summary>
        public decimal PricePaid { get; set; }


        /// <summary>
        /// Factory methode voor het creeren van een orderline met de nodige data.
        /// </summary>
        /// <returns></returns>
        public static Orderline Create(Drank drank, Leiding orderedFor, Order order)
        {
            var orderline = new Orderline()
            {
                Drank = drank,
                OrderedFor = orderedFor,
                Order = order,
                PricePaid = drank.CurrentPrijs.Waarde
            };

            return orderline;
        }
    }
}