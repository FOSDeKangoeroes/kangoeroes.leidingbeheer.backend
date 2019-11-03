using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Models.Accounting
{
    public class TabTransaction : Transaction
    {
        public Orderline Consumption { get; set; }
    }
}