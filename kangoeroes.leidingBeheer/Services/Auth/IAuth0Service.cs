using System.Threading.Tasks;
using Auth0.Core;

namespace kangoeroes.leidingBeheer.Services.Auth
{
  public interface IAuth0Service
  {
    Task<User> MakeNewUserFor(string email);

  }
}
