using AutoMapper;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Services.TotemServices.Interfaces;

namespace kangoeroes.leidingBeheer.Services.TotemServices
{
  public class TotemEntryService: ITotemEntryService
  {
    private readonly ITotemEntryRepository _totemEntryRepository;
    private readonly IMapper _mapper;

    public TotemEntryService(ITotemEntryRepository totemEntryRepository, IMapper mapper)
    {
      _totemEntryRepository = totemEntryRepository;
      _mapper = mapper;
    }

  public PagedList<TotemEntry> FindAll(ResourceParameters resourceParameters)
    {
      var entries = _totemEntryRepository.FindAll(resourceParameters);

      return entries;
    }
  }
}
