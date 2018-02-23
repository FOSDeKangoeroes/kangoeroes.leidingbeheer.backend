using System.Threading.Tasks;
using Auth0.Core;

namespace kangoeroes.leidingBeheer.Auth
{
  public interface IAuth0Service
  {
    Task<User> MakeNewUserFor(string email);

  }
}
