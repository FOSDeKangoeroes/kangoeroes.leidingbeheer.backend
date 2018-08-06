﻿using AutoMapper;
using kangoeroes.core.Models.Responses;
using kangoeroes.leidingBeheer.Data.Context;
using kangoeroes.leidingBeheer.Data.Repositories;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;
using kangoeroes.leidingBeheer.Services.Auth;
using kangoeroes.leidingBeheer.Services.TotemServices;
using kangoeroes.leidingBeheer.Services.TotemServices.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer
{
  public class Startup
  {
    public IConfigurationRoot Configuration { get; }

    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

      builder.AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors();
      //Te gebruiken database configureren
      services.AddDbContext<ApplicationDbContext>(options => {

        options.UseMySql(Configuration.GetConnectionString("Default"));
      });
      services.AddAutoMapper();

      //Mvc en bijhorende opties configureren
      services.AddMvc().AddJsonOptions(options => {

        //Loops in response worden genegeerd. Bijv: Leiding -> Tak -> Leiding -> Tak -> .. wordt Leiding -> Tak
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;


      });

      services.AddAuthentication(options =>
        {
          options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
          options.Authority = Configuration["Auth0:domain"];
          options.Audience = "admin.dekangoeroes.be";

        });

      services.AddAuthorization();

      services.AddOptions();
      RegisterDependencyInjection(services);
    }

    private void RegisterDependencyInjection(IServiceCollection services)
    {

      services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

      services.AddScoped<IUrlHelper, UrlHelper>(implementationFactory =>
      {
        var actionContext = implementationFactory.GetService<IActionContextAccessor>().ActionContext;
        return new UrlHelper(actionContext);
      });

      services.AddScoped<ApplicationDbContext>();

      services.AddTransient<ITakRepository, TakRepository>();
      services.AddTransient<ILeidingRepository, LeidingRepository>();
      services.AddTransient<ITotemRepository, TotemRepository>();
      services.AddTransient<IAdjectiefRepository, AdjectiefRepository>();
      services.AddTransient<ITotemEntryRepository, TotemEntryRepository>();
      services.AddTransient<IDrankRepository, DrankRepository>();

      services.AddSingleton<IConfiguration>(Configuration);
      services.AddTransient<IAuth0Service,Auth0Service>();
      services.AddTransient<ITotemService, TotemService>();
      services.AddTransient<IAdjectiefService, AdjectiefService>();
      services.AddTransient<ITotemEntryService, TotemEntryService>();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();

      }

      app.UseCors(builder =>
      {
        builder.WithOrigins("http://staging.admin.dekangoeroes.be","http://staging.totems.dekangoeroes.be")
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials();
      });

      app.UseExceptionHandler(options =>
      {
        options.Run(async context =>
        {
         context.Response.StatusCode = 500;
          context.Response.ContentType = "application/json";
          var response = new ApiServerErrorResponse("Oops. Er ging iets fout");
          if (env.IsDevelopment())
          {
            var ex = context.Features.Get<IExceptionHandlerFeature>();
            if (ex != null)
            {
              response.DetailedMessage = ex.Error.Message;
              response.StackTrace = ex.Error.StackTrace;
            }

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response)).ConfigureAwait(false);
          }
        });
      });

      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseAuthentication();

      app.UseMvcWithDefaultRoute();
    }
  }
}
