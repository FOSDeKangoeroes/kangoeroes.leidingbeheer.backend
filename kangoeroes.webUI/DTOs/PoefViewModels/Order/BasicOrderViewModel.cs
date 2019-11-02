using System.Collections.Generic;
using System.Linq;
using kangoeroes.webUI.DTOs.PoefViewModels.Orderline;

namespace kangoeroes.webUI.DTOs.PoefViewModels.Order
{
  public class BasicOrderViewModel
  {
    public int Id { get; set; }

    public string OrderedByNaam { get; set; }

    public decimal OrderPrice => Orderlines.Sum(x => x.PriceTotal);

    public List<BasicOrderlineViewModel> Orderlines { get; set; }
  }
}
