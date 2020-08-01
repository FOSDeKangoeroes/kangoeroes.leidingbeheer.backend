namespace kangoeroes.core.DTOs.Section
{
  public class BasicSectionDTO
  {
    public int Id { get; set; }

    public string Naam { get; set; }

    public int Volgorde { get; set; }

    public int LeidingCount { get; set; }
    
    public bool TabIsAllowed { get; set; }
  }
}
