using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace kangoeroes.webUI.Helpers
{
  public class ResourceOwnerRequirement : IAuthorizationRequirement
  {
    public ResourceOwnerRequirement()
    {
    }
  }

  public class ResourceOwnerHandler : AuthorizationHandler<ResourceOwnerRequirement>
  {
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ILogger<ResourceOwnerHandler> _logger;

    public ResourceOwnerHandler(IHttpContextAccessor contextAccessor, ILogger<ResourceOwnerHandler> logger)
    {
      _contextAccessor = contextAccessor;
      _logger = logger;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
      ResourceOwnerRequirement requirement)
    {
      // throw new Exception(context.User.ToString());
      _logger.LogDebug(context.User.Claims.ToString());
      var user = context.User;
      var claimType = ClaimTypes.Email;
      var email = user.FindFirstValue(ClaimTypes.Email);
      if (UserHasAccess(email))
      {
        context.Succeed(requirement);
      }


      return Task.CompletedTask;
    }

    private bool UserHasAccess(string currentUserEmail)
    {
      _contextAccessor.HttpContext.Request.RouteValues.TryGetValue("id", out var requestedUserId);


      if (requestedUserId == null)
      {
        return false;
      }

      string requestedUserIdInteger = (string) requestedUserId;

      if (requestedUserIdInteger != currentUserEmail)
      {
        return false;
      }

      return true;
    }
  }
}
