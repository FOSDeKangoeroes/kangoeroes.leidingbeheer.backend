using AutoMapper;
using kangoeroes.core.DTOs.Section;
using kangoeroes.core.Models;

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
