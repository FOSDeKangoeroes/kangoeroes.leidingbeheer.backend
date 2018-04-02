using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Models.Exceptions;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Models.ViewModels.Totem;
using kangoeroes.leidingBeheer.Services.TotemServices.Interfaces;

namespace kangoeroes.leidingBeheer.Services.TotemServices
{
  public class TotemService: ITotemService
  {
    private readonly ITotemRepository _totemRepository;
    private readonly IMapper _mapper;

    public TotemService(ITotemRepository totemRepository, IMapper mapper)
    {
      _totemRepository = totemRepository;
      _mapper = mapper;
    }

    public IEnumerable<BasicTotemViewModel> FindAll()
    {
      var result = _totemRepository.FindAll().ToList();

      return _mapper.Map<IEnumerable<BasicTotemViewModel>>(result);
    }

    public async Task<BasicTotemViewModel> FindByIdAsync(int id)
    {
      var result = await _totemRepository.FindByIdAsync(id);

      if (result == null)
      {
        throw new EntityNotFoundException($"Totem met id {id} werd niet gevonden");
      }

      return _mapper.Map<BasicTotemViewModel>(result);
    }


    public async Task<BasicTotemViewModel> AddTotemAsync(AddTotemViewModel viewModel)
    {
      var exists = await _totemRepository.TotemExists(viewModel.Naam) != null;

      if (exists)
      {
        throw new EntityExistsException($"Totem met naam {viewModel.Naam} bestaat al");
      }

      var newTotem = _mapper.Map<Totem>(viewModel);

      await _totemRepository.AddAsync(newTotem);
      await _totemRepository.SaveChangesAsync();

      var model = _mapper.Map<BasicTotemViewModel>(newTotem);

      return model;
    }

    public async Task<BasicTotemViewModel> UpdateTotemAsync(UpdateTotemViewModel viewModel, int id)
    {
      var totem = await _totemRepository.FindByIdAsync(id);


      if (totem == null)
      {
        throw new EntityNotFoundException($"Totem met id {id} werd niet gevonden");
      }

      var exists = await _totemRepository.FindByNaamAsync(viewModel.Naam.Trim().ToLowerInvariant()) != null;

      if (exists)
      {
        throw new EntityExistsException($"Totem met naam {viewModel.Naam} bestaat al");
      }

      totem.Naam = viewModel.Naam.Trim().ToLowerInvariant();
      await _totemRepository.SaveChangesAsync();

      return _mapper.Map<BasicTotemViewModel>(totem);
    }

  }
}
