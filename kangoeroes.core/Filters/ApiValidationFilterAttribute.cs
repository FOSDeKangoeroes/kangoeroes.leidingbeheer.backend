using kangoeroes.leidingBeheer.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace kangoeroes.leidingBeheer.Filters
{
  public class ApiValidationFilterAttribute: ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      if (!context.ModelState.IsValid)
      {
        context.Result = new BadRequestObjectResult(new ApiBadRequestResponse(context.ModelState));
      }
      base.OnActionExecuting(context);
    }
  }
}
