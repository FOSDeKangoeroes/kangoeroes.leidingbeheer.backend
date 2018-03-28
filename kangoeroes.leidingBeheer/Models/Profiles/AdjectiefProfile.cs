using AutoMapper;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Models.ViewModels.Adjectief;

namespace kangoeroes.leidingBeheer.Models.Profiles
{
  public class AdjectiefProfile: Profile
  {
    public AdjectiefProfile()
    {
      CreateMap<Adjectief, BasicAdjectiefViewModel>();
      CreateMap<AddAdjectiefViewModel, Adjectief>();
      CreateMap<UpdateAdjectiefViewModel, Adjectief>();
    }
  }
}
