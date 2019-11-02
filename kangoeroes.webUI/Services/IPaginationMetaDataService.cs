using kangoeroes.core.Helpers;
using kangoeroes.webUI.Helpers;
using Microsoft.AspNetCore.Http;

namespace kangoeroes.webUI.Services
{
  /// <summary>
  /// Service verantwoordelijk voor het toevoegen van paginatie metadata aan een response object.
  /// </summary>
  public interface IPaginationMetaDataService
  {
    /// <summary>
    /// Voegt paginatie metadata toe aan de headers het meegegeven response object.
    /// </summary>
    /// <param name="response">Response object waaraan de paginatie headers worden toegevoegd</param>
    /// <param name="data">PagedList met alle info over de paginatie</param>
    void AddMetaDataToResponse<T>(HttpResponse response, PagedList<T> data);
  }
}
