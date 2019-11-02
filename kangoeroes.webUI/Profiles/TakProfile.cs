using AutoMapper;
using kangoeroes.core.Models;
using kangoeroes.webUI.DTOs.Section;

namespace kangoeroes.webUI.Profiles
{
  public class TakProfile : Profile
  {
    public TakProfile()
    {
      CreateMap<CreateSectionDTO, Tak>();
      CreateMap<UpdateSectionDTO, Tak>();
      CreateMap<Tak, BasicSectionDTO>();
    }
  }
}
