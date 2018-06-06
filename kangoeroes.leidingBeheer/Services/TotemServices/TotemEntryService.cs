﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models.Exceptions;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Models.ViewModels.TotemEntry;
using kangoeroes.leidingBeheer.Services.TotemServices.Interfaces;

namespace kangoeroes.leidingBeheer.Services.TotemServices
{
  public class TotemEntryService : ITotemEntryService
  {
    private readonly ITotemEntryRepository _totemEntryRepository;
    private readonly ILeidingRepository _leidingRepository;
    private readonly ITotemRepository _totemRepository;
    private readonly IAdjectiefRepository _adjectiefRepository;
    private readonly IMapper _mapper;

    public TotemEntryService(ITotemEntryRepository totemEntryRepository, IMapper mapper, ILeidingRepository leidingRepository, IAdjectiefRepository adjectiefRepository, ITotemRepository totemRepository)
    {
      _totemEntryRepository = totemEntryRepository;
      _adjectiefRepository = adjectiefRepository;
      _totemRepository = totemRepository;
      _leidingRepository = leidingRepository;
      _mapper = mapper;
    }

    public PagedList<TotemEntry> FindAll(ResourceParameters resourceParameters)
    {
      var entries = _totemEntryRepository.FindAll(resourceParameters);

      return entries;
    }

    public async Task<BasicTotemEntryViewModel> FindByIdAsync(int id)
    {
      var entry = await _totemEntryRepository.FindByIdAsync(id);

      if (entry == null)
      {
        throw new EntityNotFoundException($"Getotemiseerde met id {id} bestaat niet.");
      }

      var viewmodel = _mapper.Map<BasicTotemEntryViewModel>(entry);

      return viewmodel;


    }

    public async Task<BasicTotemEntryViewModel> AddEntryAsync(AddEntryExistingLeiding viewmodel)
    {
      var leiding = _leidingRepository.FindById(viewmodel.LeidingId);

      if (leiding == null)
      {
        throw new EntityNotFoundException($"Leiding met id {viewmodel.LeidingId} bestaat niet.");
      }

      //Check if leiding already has a totem
      var totemForLeiding = await _totemEntryRepository.FindByLeidingIdAsync(leiding.Id);

      if (totemForLeiding != null)
      {
        throw new EntityExistsException($"{totemForLeiding.Leiding.Voornaam} {totemForLeiding.Leiding.Naam} heeft al een totem.");
      }

      var totem = await _totemRepository.FindByIdAsync(viewmodel.TotemId);

      if (totem == null)
      {
        throw new EntityNotFoundException($"Totem met id {viewmodel.TotemId} werd niet gevonden");
      }

      var adjectief = await _adjectiefRepository.FindByIdAsync(viewmodel.AdjectiefId);

      if (adjectief == null)
      {
        throw new EntityNotFoundException($"Adjectief met id {viewmodel.AdjectiefId} werd niet gevonden");
      }

      var newEntry = new TotemEntry
      {
        Adjectief = adjectief,
        DatumGegeven = viewmodel.DatumGegeven,
        Leiding = leiding,
        Totem = totem
      };

      if (viewmodel.VoorouderId != 0)
      {
        var voorouder = await _totemEntryRepository.FindByIdAsync(viewmodel.VoorouderId);

        if (voorouder == null)
        {
          throw new EntityNotFoundException($"Voorouder met id {viewmodel.VoorouderId} werd niet gevonden.");
        }

        newEntry.Voorouder = voorouder;
      }

      await _totemEntryRepository.AddAsync(newEntry);
      await _totemEntryRepository.SaveChangesAsync();

      var model = _mapper.Map<BasicTotemEntryViewModel>(newEntry);

      return model;

    }

    public async Task<BasicTotemEntryViewModel> AddVoorOuderAsync(int leidingId, int voorouderId)
    {
      var totemEntry = await _totemEntryRepository.FindByIdAsync(leidingId);

      if (totemEntry == null)
      {
        throw new EntityNotFoundException($"Totem voor leiding met id {leidingId} werd niet gevonden.");
      }

      var voorouder = await _totemEntryRepository.FindByIdAsync(voorouderId);

      if (voorouder == null)
      {
        throw new EntityNotFoundException($"Voorouder met id {voorouderId} werd niet gevonden.");
      }

      totemEntry.Voorouder = voorouder;
      await _totemEntryRepository.SaveChangesAsync();

      var model = _mapper.Map<BasicTotemEntryViewModel>(totemEntry);

      return model;


    }

    public async Task<BasicTotemEntryViewModel> UpdateEntry(int entryId, UpdateTotemEntryViewModel viewmodel)
    {
      var entryToUpdate = await _totemEntryRepository.FindByIdAsync(entryId);

      if (entryToUpdate == null)
      {
        throw new EntityNotFoundException($"Entry met id werd niet gevonden.");
      }

      var adjectief = await _adjectiefRepository.FindByIdAsync(viewmodel.AdjectiefId);

      if (adjectief == null)
      {
        throw new EntityNotFoundException($"Adjectief met id {viewmodel.AdjectiefId} werd niet gevonden.");
      }
      entryToUpdate.Adjectief = adjectief;

      var totem = await _totemRepository.FindByIdAsync(viewmodel.TotemId);

      if (totem == null)
      {
        throw new EntityNotFoundException($"Dier met id {viewmodel.TotemId} werd niet gevonden.");
      }

      entryToUpdate.Totem = totem;
      entryToUpdate.DatumGegeven = viewmodel.DatumGegeven;

      await _totemEntryRepository.SaveChangesAsync();

      var model = _mapper.Map<BasicTotemEntryViewModel>(entryToUpdate);

      return model;

    }

  }
}