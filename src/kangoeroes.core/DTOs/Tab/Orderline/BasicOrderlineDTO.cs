namespace kangoeroes.core.DTOs.Tab.Orderline
{
  public class BasicOrderlineDTO
  {
    public int Id { get; set; }

    public string DrankNaam { get; set; }

    public string OrderedForNaam { get; set; }

    public decimal DrinkPrice { get; set; }

    public decimal PriceTotal => DrinkPrice * Quantity;

    public int Quantity { get; set; }
  }
}
