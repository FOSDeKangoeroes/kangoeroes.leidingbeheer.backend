using AutoMapper;
using kangoeroes.core.DTOs.Adjective;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.webUI.Profiles
{
  public class AdjectiefProfile : Profile
  {
    public AdjectiefProfile()
    {
      CreateMap<Adjectief, BasicAdjectiveDTO>();
      CreateMap<CreateAdjectiveDTO, Adjectief>();
      CreateMap<UpdateAdjectiveDTO, Adjectief>();
    }
  }
}
