using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.DTOs.Animal;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models.Totems;
using kangoeroes.infrastructure;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.webUI.Services
{
  public class TotemService : ITotemService
  {
    private readonly IMapper _mapper;
    private readonly ITotemRepository _totemRepository;
    private readonly ApplicationDbContext _dbContext;

    public TotemService(ITotemRepository totemRepository, IMapper mapper, ApplicationDbContext dbContext)
    {
      _totemRepository = totemRepository;
      _mapper = mapper;
      _dbContext = dbContext;
    }

    public PagedList<BasicAnimalDTO> FindAll(ResourceParameters resourceParameters)
    {
      var result = FilterTotems(_dbContext.Totems.AsNoTracking().Include(x => x.TotemEntries).ThenInclude(x => x.Leiding), resourceParameters);

      var intermediary = from d in result
        select new BasicAnimalDTO
        {
          Id = d.Id,
          Naam = d.Naam,
          CreatedOn = d.CreatedOn,
          EntryCount = d.TotemEntries.Count(),
          ReuseDate = GetEarliestReuseDate(d)
        };

      intermediary = SortTotems(intermediary, resourceParameters);
      var pagedList = PagedList<BasicAnimalDTO>.Paginate(intermediary, resourceParameters.PageNumber, resourceParameters.PageSize);


      var newPagedList = PagedList<BasicAnimalDTO>.Create(pagedList.Item1, pagedList.Item2);

      return newPagedList;
    }

    public async Task<BasicAnimalDTO> FindByIdAsync(int id)
    {
      var result = await _totemRepository.FindByIdAsync(id);

      if (result == null) throw new EntityNotFoundException($"Totem met id {id} werd niet gevonden");

      return _mapper.Map<BasicAnimalDTO>(result);
    }


    public async Task<BasicAnimalDTO> AddTotemAsync(AddAnimalDTO viewModel)
    {
      var exists = await _totemRepository.FindByNaamAsync(viewModel.Naam) != null;

      if (exists) throw new EntityExistsException($"Totem met naam {viewModel.Naam} bestaat al");

      //Trailing spaces verwijderen uit nieuwe totem
      viewModel.Naam = viewModel.Naam.Trim();

      var newTotem = _mapper.Map<Totem>(viewModel);

      await _totemRepository.AddAsync(newTotem);
      await _totemRepository.SaveChangesAsync();

      var model = _mapper.Map<BasicAnimalDTO>(newTotem);

      return model;
    }

    public async Task<BasicAnimalDTO> UpdateTotemAsync(UpdateAnimalDTO viewModel, int id)
    {
      var totem = await _totemRepository.FindByIdAsync(id);


      if (totem == null) throw new EntityNotFoundException($"Totem met id {id} werd niet gevonden");

      totem.Naam = viewModel.Naam.Trim();
      await _totemRepository.SaveChangesAsync();

      return _mapper.Map<BasicAnimalDTO>(totem);
    }

    private IQueryable<Totem> FilterTotems(IQueryable<Totem> currentResults, ResourceParameters resourceParameters)
    {
      return !string.IsNullOrWhiteSpace(resourceParameters.Query) ? currentResults.Where(x => x.Naam.ToLower().Contains(resourceParameters.Query.ToLower())) : currentResults;
    }

    private IQueryable<BasicAnimalDTO> SortTotems(IQueryable<BasicAnimalDTO> currentResults, ResourceParameters resourceParameters)
    {
      var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;
      return !string.IsNullOrWhiteSpace(sortString) ? currentResults.OrderBy(sortString) : currentResults;
    }

    private static DateTime? GetEarliestReuseDate(Totem totem)
    {
      var entriesWithoutKnownReuseDate = totem.TotemEntries.Any(x => x.ReuseDateTotem.Year == 1);

      if (entriesWithoutKnownReuseDate)
      {
        return null;
      }

      return totem.TotemEntries.Max(x => x.ReuseDateTotem);
    }

  }
}
