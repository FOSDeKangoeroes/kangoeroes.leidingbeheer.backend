using System;
using System.Net;
using System.Threading.Tasks;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Models.Responses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace kangoeroes.webUI.Middleware
{
  public class ApplicationErrorHandlerMiddleware
  {
    private readonly RequestDelegate next;
    private readonly IHostingEnvironment env;

    public ApplicationErrorHandlerMiddleware(RequestDelegate next, IHostingEnvironment env)
    {
      this.next = next;
      this.env = env;
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        await next(context);
      }
      catch (HttpStatusCodeException e)
      {
        await HandleExceptionAsync(context, e);
      }
      catch (Exception e)
      {
        await HandleExceptionAsync(context, e);
      }
    }

    private Task HandleExceptionAsync(HttpContext context, HttpStatusCodeException exception)
    {
      var code = HttpStatusCode.InternalServerError;

      var result = exception.Message;

      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int) exception.StatusCode;
      return context.Response.WriteAsync(result);
    }

    private Task HandleExceptionAsync(HttpContext context, Exception e)
    {
      context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

      var result =
        new ApiServerErrorResponse("Er heeft zich een onverwachte fout voorgedaan. Probeer het later opnieuw.");

      if (env.IsDevelopment())
      {
        result.DetailedMessage = e.Message;
        result.StackTrace = e.StackTrace;
      }

      return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
    }
  }
}
