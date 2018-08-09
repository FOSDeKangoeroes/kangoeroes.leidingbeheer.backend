using kangoeroes.leidingBeheer.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace kangoeroes.leidingBeheer.Filters
{
  //Filter that checks every request for a valid modelState.
  //If the modelState is not valid, the controller method is not executed and a bad request (400) is returned.
  public class ModelStateIsValidAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      if (!context.ModelState.IsValid)
      {
        var errorList = ModelStateFormatter.FormatErrors(context.ModelState);
        context.Result = new BadRequestObjectResult(errorList);
      }

      base.OnActionExecuting(context);
    }
  }
}
