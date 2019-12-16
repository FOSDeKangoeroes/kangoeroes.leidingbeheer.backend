namespace kangoeroes.core.Models.Poef
{
    public class PersonOrderlineSummary
    {
        public int LeaderId { get; set; }
        
        public string Leader { get; set; }
        
        public int AmountOfConsumptions { get; set; }
        
        public decimal TotalCost { get; set; }
    }
}