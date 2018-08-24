using System;
using System.Collections.Generic;
using System.Linq;

namespace kangoeroes.leidingBeheer.Helpers
{
  public class PagedList<T> : List<T>
  {
    private PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
      TotalCount = count;
      PageSize = pageSize;
      CurrentPage = pageNumber;
      TotalPages = (int) Math.Ceiling(count / (double) pageSize);
      AddRange(items);
    }

    public int CurrentPage { get; }
    public int TotalPages { get; }
    public int PageSize { get; }
    public int TotalCount { get; }

    public bool HasPrevious => CurrentPage > 1;

    public bool HasNext => CurrentPage < TotalPages;

    /// <summary>
    /// Factory method voor het creeeren van een gepagineerde lijst uit een IQueryable.
    /// </summary>
    /// <param name="source">IQueryable van reeds gefilterde data</param>
    /// <param name="pageNumber">Pagina waarop de data moet starten</param>
    /// <param name="pageSize">Aantal entiteiten dat moet teruggegeven worden</param>
    /// <returns></returns>
    public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
    {
      var count = source.Count();
      var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

      return new PagedList<T>(items, count, pageNumber, pageSize);
    }
  }
}
