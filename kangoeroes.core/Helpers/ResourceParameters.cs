namespace kangoeroes.core.Helpers
{
  public class ResourceParameters
  {
    private int _pageSize = 25;
    private const int MaxPageSize = 100;

    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
      get { return _pageSize; }
      set { _pageSize = (value > MaxPageSize)? MaxPageSize: value; }
    }
    
    public string SortBy { get; set; } = "naam";
    public string SortOrder { get; set; } = "";
    public string Query { get; set; } = "";
  }
}
