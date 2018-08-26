using System;
using System.Text;

namespace kangoeroes.leidingBeheer.Helpers
{
  /// <summary>
  /// Utility klasse om een afkorting op te bouwen
  /// </summary>
  public class AfkortingBuilder
  {
    /// <summary>
    /// Bouwt een afkorting van 2 karakters in hoofdletters uit een gegeven string.
    /// Voorbeeld:
    /// Thomas de Wulf wordt TD
    /// Pol Janssens wordt PJ
    /// </summary>
    /// <param name="value">Waarde die afgekort dient te worden</param>
    /// <returns>Afkorting van de waarde. Bestaat uit 2 karakters.</returns>
    public static string BuildAfkorting(string value)
    {
      var builder = new StringBuilder();

      builder.Append(value[0]);

      if (!value.Contains(" "))
      {
        return builder.ToString().ToUpperInvariant();
      }

      var indexOfSpace = value.IndexOf(" ", StringComparison.Ordinal);
      var firstCharAfterSpace = value[indexOfSpace + 1];
      builder.Append(firstCharAfterSpace);

      return builder.ToString().ToUpperInvariant();
    }
  }
}
