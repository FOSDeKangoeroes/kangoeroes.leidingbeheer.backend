using AutoMapper;
using kangoeroes.core.Models;
using kangoeroes.webUI.DTOs.Leader;

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
