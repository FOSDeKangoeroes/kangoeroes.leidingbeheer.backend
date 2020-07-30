using System;
using System.Security.Claims;
using AutoMapper;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Services;
using kangoeroes.infrastructure;
using kangoeroes.infrastructure.Repositories;
using kangoeroes.infrastructure.Repositories.Accounting;
using kangoeroes.infrastructure.Repositories.PoefRepositories;
using kangoeroes.infrastructure.Repositories.TotemsRepositories;
using kangoeroes.webUI.Helpers;
using kangoeroes.webUI.Interfaces;
using kangoeroes.webUI.Middleware;
using kangoeroes.webUI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace kangoeroes.webUI
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);
      builder.AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
      services.AddCors();
      //Te gebruiken database configureren
      services.AddDbContext<ApplicationDbContext>(options =>
      {
        options.UseMySql(Configuration.GetConnectionString("Default"));
      });
      services.AddAutoMapper(typeof(Startup));

      //Mvc en bijhorende opties configureren
      services.AddControllers().AddNewtonsoftJson(options =>
      {
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
          options.Authority = $"https://{Configuration["Auth0:Domain"]}/";
          options.Audience = Configuration["Auth0:Audience"];
        });

      services.AddAuthorization(options =>
      {
        options.AddPolicy("ResourceOwner",
          policy =>
          {
            policy.RequireAuthenticatedUser();
            policy.Requirements.Add(new ResourceOwnerRequirement());
          })
          ;
      });

      services.AddOptions();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo() {Title = "Kangoeroes API - V1", Version = "v1"});


        // Endpoint informatie ophalen uit XML-documentatie
        /* var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
         var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
         c.IncludeXmlComments(xmlPath);*/
      });
      RegisterDependencyInjection(services);
    }

    private void RegisterDependencyInjection(IServiceCollection services)
    {
      services.AddHttpContextAccessor();
      services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
      services.AddSingleton<IAuthorizationHandler, ResourceOwnerHandler>();

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
      services.AddTransient<IDrankTypeRepository, DrankTypeRepository>();
      services.AddTransient<IOrderRepository, OrderRepository>();
      services.AddTransient<IOrderlineRepository, OrderlineRepository>();
      services.AddTransient<IAccountRepository, AccountRepository>();
      services.AddTransient<IPeriodRepository, PeriodRepository>();

      services.AddSingleton<IConfiguration>(Configuration);

      services.AddTransient<ITotemService, TotemService>();
      services.AddTransient<IAdjectiefService, AdjectiefService>();
      services.AddTransient<ITotemEntryService, TotemEntryService>();
      services.AddTransient<IDrankService, DrankService>();
      services.AddTransient<IDrankTypeService, DrankTypeService>();
      services.AddTransient<IOrderService, OrderService>();
      services.AddTransient<ILeaderService, LeaderService>();
      services.AddTransient<IOrderlineService, OrderlineService>();
      services.AddTransient<IPeriodService, PeriodService>();

      services.AddTransient<IPaginationMetaDataService, PaginationMetaDataService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

      app.UseCors(builder =>
      {
        if (env.IsDevelopment())
        {
          builder.WithOrigins("http://localhost:4200", "http://localhost:4300", "http://localhost:4400")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithExposedHeaders("X-Pagination");
        }

        builder.WithOrigins("http://staging.admin.dekangoeroes.be", "http://staging.totems.dekangoeroes.be",
            "https://totems-staging.azurewebsites.net/")
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials();
      });

      app.UseMiddleware<ApplicationErrorHandlerMiddleware>();

      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseAuthentication();


      app.UseRouting();
      app.UseAuthorization();
      // Swagger middleware toevoegen om JSON endpoint te exposen
      app.UseSwagger();

      // Swagger middleware om UI endpoint te exposen
      app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kangoeroes API - V1"); });

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}
