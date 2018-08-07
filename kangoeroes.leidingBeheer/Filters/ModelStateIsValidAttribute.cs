﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace kangoeroes.leidingBeheer.Filters
{
  //Filter that checks every request for a valid modelState.
  //If the modelState is not valid, the controller method is not executed and a bad request (400) is returned.
  public class ModelStateIsValidAttribute: ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      if (!context.ModelState.IsValid)
      {
        context.Result = new BadRequestObjectResult(context.ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage + " " + v.Exception?.Message));
      }
      base.OnActionExecuting(context);
    }


  }
}
