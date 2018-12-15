using System;

namespace kangoeroes.webUI.Helpers.ResourceParameters
{
  /// <inheritdoc />
  public class OrderResourceParameters: ResourceParameters
  {
    /// <summary>
    /// Datum vanaf wanneer de orders moeten opgehaald worden
    /// </summary>
    public DateTime Start { get; set; }

    /// <summary>
    /// Datum tot wanneer de orders moeten opgehaald worden.
    /// </summary>
    public DateTime End { get; set; }
  }
}
