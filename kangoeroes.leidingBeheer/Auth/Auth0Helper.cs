using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using kangoeroes.leidingBeheer.Models.AuthViewModels;
using kangoeroes.leidingBeheer.Network;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;


namespace kangoeroes.leidingBeheer.Auth
{
  public class Auth0Helper
  {
    private IConfiguration _configuration;
    private RestClient _client;


    public Auth0Helper(IConfiguration configuration)
    {
      this._configuration = configuration;
      var url = _configuration["Auth0:domain"];
      _client = new RestClient(url);
    }


    public UserViewModel MakeNewUserFor(string email)
    {
      //Get token
      var token = GetToken();
      var password = GenerateRandomPassword();
      var user = CreateUser(email, token.Access_Token, password);
      TriggerPasswordResetForUser(email);

      return user;
    }

    private TokenViewModel GetToken()
    {

      var clientId = _configuration["Auth0:ni_client_id"];
      var clientSecret = _configuration["Auth0:ni_client_secret"];
      var audience = _configuration["Auth0:audience"];

      var request = new RestRequest("/oauth/token", Method.POST);
      request.AddHeader("content-type", "application/json");
      request.AddParameter("application/json", "{\"client_id\":\"" + clientId + "\"" +
                                               ",\"client_secret\":\"" + clientSecret + "\"," +
                                               "\"audience\":\"" + audience + "\"," +
                                               "\"grant_type\":\"client_credentials\"}",
        ParameterType.RequestBody);
      IRestResponse response = _client.Execute(request);

      if (response.IsSuccessful)
      {
        var model = JsonConvert.DeserializeObject<TokenViewModel>(response.Content);
        return model;
      }
      throw new Exception($"Token kon niet opgehaald worden. {response.Content}");


    }


    private UserViewModel CreateUser(string email, string token, string password)
    {
      var request = new RestRequest("/api/v2/users", Method.POST);
      var connection = _configuration["Auth0:standard_connection"];
      request.AddHeader("content-type", "application/json");
      request.AddHeader("authorization",
        $"Bearer {token}");

      request.AddParameter("application/json",
        "{\"connection\": \"" + connection + "\"," +
        "\"email\":\"" + email +
        "\",\"password\": \"" + password + "\", " +
        "\"email_verified\": true}",
        ParameterType.RequestBody);

      IRestResponse response = _client.Execute(request);
      if (response.IsSuccessful)
      {
            var model = JsonConvert.DeserializeObject<UserViewModel>(response.Content);
            return model;
      }

      throw new Exception("Gebruiker kon niet aangemaakt worden");


    }

    private void TriggerPasswordResetForUser(string email)
    {

      var clientId = _configuration["Auth0:ni_client_id"];
      var request = new RestRequest("/dbconnections/change_password", Method.POST);
      var connection = _configuration["Auth0:standard_connection"];
      request.AddHeader("content-type", "application/x-www-form-urlencoded");
      request.AddHeader("cache-control", "no-cache");
      request.AddParameter("application/x-www-form-urlencoded",
        $"client_id={clientId}&email={email}&connection={connection}", ParameterType.RequestBody);
      IRestResponse response = _client.Execute(request);
      if (!response.IsSuccessful)
      {
        throw new Exception("Wachtwoord reset werd niet gestart.");
      }
    }

    private string GenerateRandomPassword()
    {
      string[] randomChars = new[]
      {
        "ABCDEFGHJKLMNOPQRSTUVWXYZ", // uppercase
        "abcdefghijkmnopqrstuvwxyz", // lowercase
        "0123456789", // digits
        "!@$?_-" // non-alphanumeric
      };
      Random random = new Random(Environment.TickCount);
      List<char> chars = new List<char>();

      int passwordLength = Int32.Parse(_configuration["Auth0:passwordLength"]);
      while (chars.Count < passwordLength)
      {
        chars.Insert(random.Next(0, chars.Count),
          randomChars[0][random.Next(0, randomChars[0].Length)]);

        chars.Insert(random.Next(0, chars.Count),
          randomChars[1][random.Next(0, randomChars[1].Length)]);

        chars.Insert(random.Next(0, chars.Count),
          randomChars[2][random.Next(0, randomChars[2].Length)]);
      }

      return new string(chars.ToArray());
    }
  }
}
