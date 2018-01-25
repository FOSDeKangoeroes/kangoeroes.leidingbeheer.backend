using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using kangoeroes.leidingBeheer.Models.AuthViewModels;
using kangoeroes.leidingBeheer.Network;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Http;
using Microsoft.Extensions.Configuration;
using RestEase;


namespace kangoeroes.leidingBeheer.Auth
{
  public class Auth0Helper
  {
    private IConfiguration _configuration;


    public Auth0Helper(IConfiguration configuration)
    {
      this._configuration = configuration;
    }



    public async Task<TokenViewModel> GetTokenAsync()
    {

      var url = _configuration["Auth0:domain"];
      var clientId = _configuration["Auth0:ni_client_id"];
      var clientSecret = _configuration["Auth0:ni_client_secret"];
      var audience = _configuration["Auth0:audience"];

      var keyValues = new Dictionary<string, string>();
      keyValues.Add("grant_type", "client_credentials");
      keyValues.Add("client_id", clientId);
      keyValues.Add("client_secret", clientSecret);
      keyValues.Add("audience", audience);

      IAuth0Api api = RestClient.For<IAuth0Api>(url);

      var result = await api.GetTokenAsync(keyValues);

      return result;


    }

  }
}
