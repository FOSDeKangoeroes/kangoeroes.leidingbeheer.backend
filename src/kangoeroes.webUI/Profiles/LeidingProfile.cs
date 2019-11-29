using AutoMapper;
using kangoeroes.core.DTOs.Leader;
using kangoeroes.core.Models;

namespace kangoeroes.webUI.Profiles
{
  public class LeidingProfile : Profile
  {
    public LeidingProfile()
    {
      CreateMap<Leiding, BasicLeaderDTO>();
      CreateMap<UpdateLeaderDTO, Leiding>();
    }
  }
}
