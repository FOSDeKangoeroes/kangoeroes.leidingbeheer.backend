using System.Collections.Generic;
using kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Orderline;

namespace kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Order
{
  public class BasicOrderViewModel
  {
    public int Id { get; set; }

    public string OrderedByNaam { get; set; }

    public List<BasicOrderlineViewModel> Orderlines { get; set; }
  }
}
