using System;
using System.Net;
using System.Threading.Tasks;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Models.Responses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace kangoeroes.webUI.Middleware
{
  public class ApplicationErrorHandlerMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly IHostingEnvironment _env;
    private readonly ILogger<ApplicationErrorHandlerMiddleware> _logger;

    public ApplicationErrorHandlerMiddleware(RequestDelegate next, IHostingEnvironment env, ILogger<ApplicationErrorHandlerMiddleware> logger)
    {
      _next = next;
      _env = env;
      _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (HttpStatusCodeException e)
      {
        await HandleExceptionAsync(context, e);
        throw;
      }
      catch (Exception e)
      {
        await HandleExceptionAsync(context, e);
        throw;
      }
    }

    /// <summary>
    /// Handles exceptions of our own custom types. These allow for a status code to be provided.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="exception"></param>
    /// <returns></returns>
    private Task HandleExceptionAsync(HttpContext context, HttpStatusCodeException exception)
    {
      var result = exception.Message;

      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int) exception.StatusCode;
      return context.Response.WriteAsync(result);
    }

    /// <summary>
    /// Handles all exceptions thrown not by us. These are all unexpected exceptions.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="e"></param>
    /// <returns></returns>
    private Task HandleExceptionAsync(HttpContext context, Exception e)
    {
      context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

      var result =
        new ApiServerErrorResponse("Er heeft zich een onverwachte fout voorgedaan. Probeer het later opnieuw.");

      if (_env.IsDevelopment())
      {
        result.DetailedMessage = e.Message;
        result.StackTrace = e.StackTrace;
      }

      return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
    }
  }
}
