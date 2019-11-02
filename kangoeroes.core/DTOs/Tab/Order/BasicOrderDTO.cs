using System.Collections.Generic;
using System.Linq;
using kangoeroes.core.DTOs.Tab.Orderline;

namespace kangoeroes.core.DTOs.Tab.Order
{
  public class BasicOrderDTO
  {
    public int Id { get; set; }

    public string OrderedByNaam { get; set; }

    public decimal OrderPrice => Orderlines.Sum(x => x.PriceTotal);

    public List<BasicOrderlineDTO> Orderlines { get; set; }
  }
}
