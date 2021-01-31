using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using kangoeroes.infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace kangoeroes.webUI.Helpers
{
  public class IsLeaderRequirement : IAuthorizationRequirement
  {
    public IsLeaderRequirement()
    {
    }
  }

  public class IsLeaderHandler : AuthorizationHandler<IsLeaderRequirement>
  {
    private readonly ILogger<IsLeaderHandler> _logger;
    private readonly ApplicationDbContext _dbContext;

    public IsLeaderHandler(IHttpContextAccessor contextAccessor, ILogger<IsLeaderHandler> logger, ApplicationDbContext dbContext)
    {
      _logger = logger;
      _dbContext = dbContext;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
      IsLeaderRequirement requirement)
    {
      // throw new Exception(context.User.ToString());
      _logger.LogDebug(context.User.Claims.ToString());
      var user = context.User;
      var email = user.FindFirstValue(ClaimTypes.Email);

      var leader = await _dbContext.Leiding.FirstOrDefaultAsync(x => x.Email == email);

      if (leader != null)
      {
        context.Succeed(requirement);
      }
    }
  }
}
