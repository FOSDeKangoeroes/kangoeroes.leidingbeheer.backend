namespace kangoeroes.leidingBeheer.ViewModels.PoefViewModels.Orderline
{
  public class BasicOrderlineViewModel
  {
    public int Id { get; set; }

    public string DrankNaam { get; set; }

    public string OrderedForNaam { get; set; }

    public decimal DrinkPrice { get; set; }

    public decimal PriceTotal => DrinkPrice * Quantity;

    public int Quantity { get; set; }
  }
}
