using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.DTOs.Animal;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.core.Services
{
  public class TotemService : ITotemService
  {
    private readonly IMapper _mapper;
    private readonly ITotemRepository _totemRepository;

    public TotemService(ITotemRepository totemRepository, IMapper mapper)
    {
      _totemRepository = totemRepository;
      _mapper = mapper;
    }

    public PagedList<Totem> FindAll(ResourceParameters resourceParameters)
    {
      var result = _totemRepository.FindAll(resourceParameters);

      return result;
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
  }
}
