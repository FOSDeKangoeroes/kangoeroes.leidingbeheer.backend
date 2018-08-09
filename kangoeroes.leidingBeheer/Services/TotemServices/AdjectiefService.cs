using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Models.Exceptions;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Helpers.ResourceParameters;
using kangoeroes.leidingBeheer.Services.TotemServices.Interfaces;
using kangoeroes.leidingBeheer.ViewModels.ViewModels.Adjectief;

namespace kangoeroes.leidingBeheer.Services.TotemServices
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

    public async Task<BasicAdjectiefViewModel> FindByIdAsync(int id)
    {
      var result = await _adjectiefRepository.FindByIdAsync(id);

      if (result == null) throw new EntityNotFoundException($"Adjectief met id {id} werd niet gevonden");

      return _mapper.Map<BasicAdjectiefViewModel>(result);
    }

    public async Task<BasicAdjectiefViewModel> AddAdjectief(AddAdjectiefViewModel viewModel)
    {
      var exists = await _adjectiefRepository.FindByNaamAsync(viewModel.Naam) != null;

      if (exists) throw new EntityExistsException($"Adjectief \'{viewModel.Naam}\' bestaat al.");

      var newAdjectief = _mapper.Map<Adjectief>(viewModel);

      await _adjectiefRepository.AddAsync(newAdjectief);
      await _adjectiefRepository.SaveChangesAsync();

      var model = _mapper.Map<BasicAdjectiefViewModel>(newAdjectief);

      return model;
    }

    public async Task<BasicAdjectiefViewModel> UpdateAdjectief(int adjectiefId, UpdateAdjectiefViewModel viewmodel)
    {
      var adjectief = await _adjectiefRepository.FindByIdAsync(adjectiefId);

      if (adjectief == null) throw new EntityNotFoundException($"Adjectief met id {adjectiefId} werd niet gevonden");

      adjectief = _mapper.Map(viewmodel, adjectief);
      await _adjectiefRepository.SaveChangesAsync();

      var model = _mapper.Map<BasicAdjectiefViewModel>(adjectief);

      return model;
    }
  }
}
