using AutoMapper;
using kangoeroes.leidingBeheer.Models.ViewModels.Tak;

namespace kangoeroes.leidingBeheer.Models.Profiles.Tak
{
  public class TakProfile: Profile
  {
    public TakProfile()
    {
      CreateMap<AddTakViewModel, core.Models.Tak>();
      CreateMap<UpdateTakViewModel, core.Models.Tak>();

    }
  }
}
