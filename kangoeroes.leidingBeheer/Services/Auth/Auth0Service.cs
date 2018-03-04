using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.Core;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using kangoeroes.leidingBeheer.Models.AuthViewModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace kangoeroes.leidingBeheer.Services.Auth
{
  public class Auth0Service : IAuth0Service
  {
    private readonly IConfiguration _configuration;
    private readonly RestClient _client;
    private readonly ManagementApiClient _managementApi;
    private readonly AuthenticationApiClient _authenticationApi;


    public Auth0Service(IConfiguration configuration)
    {
      _configuration = configuration;



      var url = _configuration["Auth0:domain"];
      _client = new RestClient(url);

      var accessToken = GetToken().AccessToken;

      var uri = new Uri($"{_configuration["Auth0:domain"]}/api/v2");
      _managementApi = new ManagementApiClient(accessToken, uri);
      var authUri = new Uri(_configuration["Auth0:domain"]);
      _authenticationApi = new AuthenticationApiClient(authUri);
    }


    public async Task<User> MakeNewUserFor(string email)
    {
      //Get token to access auth0 api
      var token = GetToken();

      //Random password for the new user
      var password = GenerateRandomPassword();

      //Create the new user in auth0
      var user = await CreateUser(email, token.AccessToken, password);

      //Trigger a password reset for the newly created user
      await TriggerPasswordResetForUser(email);

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


      var response = _client.Execute(request);

      if (response.IsSuccessful)
      {
        var model = JsonConvert.DeserializeObject<TokenViewModel>(response.Content);
        return model;
      }

      // If we got this far, request was unsuccessful. Throw an exception
      throw new ApiException(response.StatusCode, new ApiError() {Message = response.ErrorMessage});
    }


    private async Task<User> CreateUser(string email, string token, string password)
    {
      var createRequest = new UserCreateRequest()
      {
        Email = email,
        Password = password,
        EmailVerified = true,
        Connection = _configuration["Auth0:standard_connection"]
      };
      var user = await _managementApi.Users.CreateAsync(createRequest);

      return user;
    }

    private async Task<string> TriggerPasswordResetForUser(string email)
    {
      var uri = new Uri($"{_configuration["Auth0:domain"]}");
      var clientId = _configuration["Auth0:ni_client_id"];
      var connection = _configuration["Auth0:standard_connection"];

      var resetRequest = new ChangePasswordRequest()
      {
        ClientId = clientId,
        Connection = connection,
        Email = email
      };
      return await _authenticationApi.ChangePasswordAsync(resetRequest);
    }


    //Very basic random password generator
    private string GenerateRandomPassword()
    {
      string[] randomChars =
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
