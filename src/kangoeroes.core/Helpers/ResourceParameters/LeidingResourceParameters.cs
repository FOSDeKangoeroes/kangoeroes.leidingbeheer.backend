namespace kangoeroes.core.Helpers.ResourceParameters
{
  /// <inheritdoc />
  public class LeidingResourceParameters : ResourceParameters
  {
    /// <summary>
    /// Aangeven voor welke tak leiding moet opgehaald worden.
    /// </summary>
    public int Tak { get; set; } = 0;

    /// <summary>
    /// If Tab is set to true, only leaders that are eligible for tab privileges are returned.
    /// </summary>
    public bool Tab { get; set; } = false;
  }
}
