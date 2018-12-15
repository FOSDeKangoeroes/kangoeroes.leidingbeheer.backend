using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace kangoeroes.webUI.Helpers
{
  public class ModelStateFormatter
  {
    public static IEnumerable<string> FormatErrors(ModelStateDictionary modelState)
    {
      return modelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage + " " + v.Exception?.Message);
    }
  }
}
