﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core;
using kangoeroes.leidingBeheer.ViewModels.AuthViewModels;
using Microsoft.AspNetCore.Mvc;

namespace kangoeroes.leidingBeheer.Services.Auth
{
  public interface IAuth0Service
  {
    Task<User> MakeNewUserFor(string email);
    IEnumerable<RoleViewModel> GetAllRoles();
    IEnumerable<UserRolesViewModel> GetAllRolesForUser(string authId);
    bool AddRoleToUser(string authId, string roleId);
    bool RemoveRoleFromUser(string authId, string roleId);
  }
}
