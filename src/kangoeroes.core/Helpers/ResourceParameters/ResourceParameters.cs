namespace kangoeroes.core.Helpers.ResourceParameters
{
  /// <summary>
  /// Standaard parameters die bij elke GET request die een lijst teruggeeft kunnen meegegeven worden.
  /// </summary>
  public class ResourceParameters
  {
    private const int MaxPageSize = 1000;
    private int _pageSize = 100;

    /// <summary>
    /// Terug te geven pagina
    /// </summary>
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// Aantal resultaten die per pagina moeten teruggegeven worden. Houdt rekening met de MaxPageSize die hardcoded is (bad practice, but I don't care)
    /// </summary>
    public int PageSize
    {
      get => _pageSize;
      set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }

    /// <summary>
    /// Veld waarop gesorteerd moet worden.
    /// </summary>
    public string SortBy { get; set; } = "";

    /// <summary>
    /// Sorteervolgorde (asc of desc) TODO: omzetten naar enum?
    /// </summary>
    public string SortOrder { get; set; } = "";

    /// <summary>
    /// String om te zoeken in de elementen. Matching criteria hangt af van de repository implementatie.
    /// </summary>
    public string Query { get; set; } = "";

    public string GetFullSortString() => SortBy + " " + SortOrder;
  }
}
