using System;
using System.Text;

namespace kangoeroes.webUI.Helpers
{
  /// <summary>
  /// Utility klasse om een afkorting op te bouwen
  /// </summary>
  public class AfkortingBuilder
  {
    /// <summary>
    /// Bouwt een afkorting van 2 karakters in hoofdletters uit een gegeven string.
    /// Voorbeeld:
    /// Thomas de Wulf wordt TD,
    /// Pol Janssens wordt PJ.
    /// </summary>
    /// <param name="value">Waarde die afgekort dient te worden</param>
    /// <returns>Afkorting van de waarde. Bestaat uit 2 karakters.</returns>
    public static string BuildAfkorting(string value)
    {
      var builder = new StringBuilder();

      //Eerste letter van de gegeven waarde steeds opnemen in de afkorting.
      builder.Append(value[0]);

      // Als er een 2e woord is, eerste letter van het 2e woord opnemen in de afkorting
      if (value.Contains(" "))
      {
        var indexOfSpace = value.IndexOf(" ", StringComparison.Ordinal);
        var firstCharAfterSpace = value[indexOfSpace + 1];
        builder.Append(firstCharAfterSpace);
      }

      //Opgebouwde afkorting volledig overzetten naar hoofdletters.
      return builder.ToString().ToUpperInvariant();
    }
  }
}
