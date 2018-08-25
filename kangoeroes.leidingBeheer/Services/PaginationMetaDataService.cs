using kangoeroes.leidingBeheer.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer.Services
{
  /// <inheritdoc />
  public class PaginationMetaDataService: IPaginationMetaDataService
  {
    /// <inheritdoc />
    public void AddMetaDataToResponse<T>(HttpResponse response, PagedList<T> data)
    {
      var paginationMetaData = new
      {
        totalCount = data.TotalCount,
        pageSize = data.PageSize,
        currentPage = data.CurrentPage,
        totalPages = data.TotalPages
      };

      response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetaData));
    }
  }
}
