using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace kangoeroes.core.Helpers
{
  public class PagedList<T> : List<T>
  {
    public PagedList()
    {
      
    }
    private PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
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
    public static PagedList<T> QueryAndCreate(IQueryable<T> source, int pageNumber, int pageSize)
    {
      var count = source.Count();
      var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

      return new PagedList<T>(items, count, pageNumber, pageSize);
    }

    public static (PagedListProperties, IQueryable<T>) Paginate(IQueryable<T> source, int pageNumber, int pageSize)
    {
      var count = source.Count();
      var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

      var properties = new PagedListProperties
      {
        Count = count,
        PageNumber = pageNumber,
        PageSize = pageSize
      };

      return (properties, items);
    }

    public static PagedList<T> Create(PagedListProperties properties, IEnumerable<T> items )
    {
      return new(items, properties.Count, properties.PageNumber, properties.PageSize);
    }

    public static PagedList<T> QueryAndCreate(IEnumerable<T> source, int pageNumber, int pageSize)
    {
      var count = source.Count();
      var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

      return new PagedList<T>(items, count, pageNumber, pageSize);
    }
  }

  public class PagedListProperties
  {
    public int Count { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
  }
}
