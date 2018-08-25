using kangoeroes.leidingBeheer.Helpers;
using Microsoft.AspNetCore.Http;

namespace kangoeroes.leidingBeheer.Services
{
  /// <summary>
  /// Service verantwoordelijk voor het toevoegen van paginatie metadata aan een response object.
  /// </summary>
  /// <typeparam name="T">Type van de data</typeparam>
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
