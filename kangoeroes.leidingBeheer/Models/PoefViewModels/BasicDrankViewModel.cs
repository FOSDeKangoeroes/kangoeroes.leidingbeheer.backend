namespace kangoeroes.leidingBeheer.Models.PoefViewModels
{
  public class BasicDrankViewModel
  {
    public int Id { get; set; }
    public string Naam { get; set; }
    public bool InStock { get; set; }
    public int TypeId { get; set; }
    public string TypeNaam { get; set; }
  }
}
