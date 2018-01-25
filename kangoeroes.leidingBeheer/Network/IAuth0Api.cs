using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.leidingBeheer.Models.AuthViewModels;
using RestEase;

namespace kangoeroes.leidingBeheer.Network
{
  public interface IAuth0Api
  {
    [Post("/oauth/token")]
    Task<TokenViewModel> GetTokenAsync([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string,string> body);
  }
}
