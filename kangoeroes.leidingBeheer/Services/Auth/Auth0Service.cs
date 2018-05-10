using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.Core;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using kangoeroes.leidingBeheer.Helpers;
using kangoeroes.leidingBeheer.Models.AuthViewModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using static System.Int32;

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


    private TokenViewModel GetToken(string audience = "")
    {
      if (string.IsNullOrEmpty(audience))
      {
        audience = _configuration["Auth0:audience"];
      }

      var clientId = _configuration["Auth0:ni_client_id"];
      var clientSecret = _configuration["Auth0:ni_client_secret"];

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

      int passwordLength = Parse(_configuration["Auth0:passwordLength"]);
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


    public IEnumerable<RoleViewModel> GetAllRoles()
    {
      var token = GetToken(_configuration["Auth0:authorization_audience"]);
      var basUrl = _configuration["Auth0:authorization_url"];


      var restClient = new RestClient(basUrl);
      var request = new RestRequest("/roles", Method.GET);
      request.AddHeader("Authorization", $"Bearer {token.AccessToken}");



      var response = restClient.Execute(request);

      if (response.IsSuccessful)
      {
        var model = JsonConvert.DeserializeObject<RolesViewModel>(response.Content);
        return model.Roles;
      }

      // If we got this far, request was unsuccessful. Throw an exception
      throw new ApiException(response.StatusCode, new ApiError() {Message = response.ErrorMessage});
    }

    private IEnumerable<RoleViewModel> GetAllRolesAssignedToUser(string authId)
    {

      var token = GetToken(_configuration["Auth0:authorization_audience"]);
      var basUrl = _configuration["Auth0:authorization_url"];


      var restClient = new RestClient(basUrl);


      //Rollen toegekend aan gebruiker ophalen
      var requestRolesForUser = new RestRequest($"/users/{authId}/roles", Method.GET);
      requestRolesForUser.AddHeader("Authorization", $"Bearer {token.AccessToken}");



      var responseRolesForUser = restClient.Execute(requestRolesForUser);



      if (responseRolesForUser.IsSuccessful)
      {
        var rolesForUser = JsonConvert.DeserializeObject<List<RoleViewModel>>(responseRolesForUser.Content);
        return rolesForUser;
      }


      throw new ApiException(responseRolesForUser.StatusCode, new ApiError() {Message = responseRolesForUser.ErrorMessage});

    }

    public IEnumerable<UserRolesViewModel> GetAllRolesForUser(string authId)
    {
      //Alle rollen voor de opgegeven gebruiker ophalen
      var rolesForUser = GetAllRolesAssignedToUser(authId).ToList();


      //Alle rollen ophalen
      var allRoles = GetAllRoles();

      //Niet toegekende rollen bepalen
      var nonActiveRoles = allRoles.Except(rolesForUser,new RoleComparer()).ToList();

      //Terug te geven data opbouwen
      List<UserRolesViewModel> model = rolesForUser.Select(role => new UserRolesViewModel
        {
          IsActive = true,
          RoleId = role.Id,
          RoleName = role.Name
        })
        .ToList();

      model.AddRange(nonActiveRoles.Select(role => new UserRolesViewModel
      {
        IsActive = false,
        RoleId = role.Id,
        RoleName = role.Name
      }));

      return model;
    }

    public bool AddRoleToUser(string authId, string roleId)
    {
      var token = GetToken(_configuration["Auth0:authorization_audience"]);
      var basUrl = _configuration["Auth0:authorization_url"];


      var restClient = new RestClient(basUrl);

      var request = new RestRequest($"/users/{authId}/roles", Method.PATCH);
      request.AddHeader("Authorization", $"Bearer {token.AccessToken}");
      var array = new string[1];
      array[0] = roleId;

      request.AddJsonBody(JsonConvert.SerializeObject(array));

      var response = restClient.Execute(request);

      if (response.IsSuccessful)
      {
        return true;
      }

      throw new ApiException(response.StatusCode, new ApiError() {Message = response.ErrorMessage});


    }

    public bool RemoveRoleFromUser(string authId, string roleId)
    {
      var token = GetToken(_configuration["Auth0:authorization_audience"]);
      var basUrl = _configuration["Auth0:authorization_url"];


      var restClient = new RestClient(basUrl);


      var request = new RestRequest($"/users/{authId}/roles", Method.DELETE);
      request.AddHeader("Authorization", $"Bearer {token.AccessToken}");
      var array = new string[1];
      array[0] = roleId;

      request.AddJsonBody(JsonConvert.SerializeObject(array));

      var response = restClient.Execute(request);

      if (response.IsSuccessful)
      {
        return true;
      }

      throw new ApiException(response.StatusCode, new ApiError() {Message = response.ErrorMessage});
    }
  }
}
