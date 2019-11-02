using AutoMapper;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.DTOs.Adjective;

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
