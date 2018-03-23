namespace kangoeroes.core.Helpers
{
  public class LeidingResourceParameters : ResourceParameters
  {
    public string SortBy { get; set; } = "naam";
    public string SortOrder { get; set; } = "";
    public string Query { get; set; } = "";
    public int Tak { get; set; } = 0;
  }
}
