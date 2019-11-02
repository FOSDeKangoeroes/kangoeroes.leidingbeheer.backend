using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.DTOs.Adjective;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.core.Services
{
  public class AdjectiefService : IAdjectiefService
  {
    private readonly IAdjectiefRepository _adjectiefRepository;
    private readonly IMapper _mapper;

    public AdjectiefService(IAdjectiefRepository adjectiefRepository, IMapper mapper)
    {
      _adjectiefRepository = adjectiefRepository;
      _mapper = mapper;
    }

    public PagedList<Adjectief> FindAll(ResourceParameters resourceParameters)
    {
      var result = _adjectiefRepository.FindAll(resourceParameters);

      return result;
    }

    public async Task<BasicAdjectiveDTO> FindByIdAsync(int id)
    {
      var result = await _adjectiefRepository.FindByIdAsync(id);

      if (result == null) throw new EntityNotFoundException($"Adjectief met id {id} werd niet gevonden");

      return _mapper.Map<BasicAdjectiveDTO>(result);
    }

    public async Task<BasicAdjectiveDTO> AddAdjectief(CreateAdjectiveDTO viewModel)
    {
      var exists = await _adjectiefRepository.FindByNaamAsync(viewModel.Naam) != null;

      if (exists) throw new EntityExistsException($"Adjectief \'{viewModel.Naam}\' bestaat al.");

      var newAdjectief = _mapper.Map<Adjectief>(viewModel);

      await _adjectiefRepository.AddAsync(newAdjectief);
      await _adjectiefRepository.SaveChangesAsync();

      var model = _mapper.Map<BasicAdjectiveDTO>(newAdjectief);

      return model;
    }

    public async Task<BasicAdjectiveDTO> UpdateAdjectief(int adjectiefId, UpdateAdjectiveDTO viewmodel)
    {
      var adjectief = await _adjectiefRepository.FindByIdAsync(adjectiefId);

      if (adjectief == null) throw new EntityNotFoundException($"Adjectief met id {adjectiefId} werd niet gevonden");

      adjectief = _mapper.Map(viewmodel, adjectief);
      await _adjectiefRepository.SaveChangesAsync();

      var model = _mapper.Map<BasicAdjectiveDTO>(adjectief);

      return model;
    }
  }
}
