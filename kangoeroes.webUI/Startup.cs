using AutoMapper;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Models.Responses;
using kangoeroes.webUI.Data.Context;
using kangoeroes.webUI.Data.Repositories;
using kangoeroes.webUI.Data.Repositories.PoefRepositories;
using kangoeroes.webUI.Data.Repositories.TotemsRepositories;
using kangoeroes.webUI.Interfaces;
using kangoeroes.webUI.Services;
using kangoeroes.webUI.Services.PoefServices;
using kangoeroes.webUI.Services.PoefServices.Interfaces;
using kangoeroes.webUI.Services.TotemServices;
using kangoeroes.webUI.Services.TotemServices.Interfaces;
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
using Swashbuckle.AspNetCore.Swagger;

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
      services.AddCors();
      //Te gebruiken database configureren
      services.AddDbContext<ApplicationDbContext>(options =>
      {
        options.UseMySql(Configuration.GetConnectionString("Default"));
      });
      services.AddAutoMapper();

      //Mvc en bijhorende opties configureren
      services.AddMvc().AddJsonOptions(options =>
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
          options.Authority = Configuration["Auth0:domain"];
          options.Audience = "admin.dekangoeroes.be";
        });

      services.AddAuthorization();

      services.AddOptions();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info { Title = "Kangoeroes API - V1", Version = "v1" });



        // Endpoint informatie ophalen uit XML-documentatie
       /* var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);*/

      });
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
      services.AddTransient<IDrankTypeRepository, DrankTypeRepository>();
      services.AddTransient<IOrderRepository, OrderRepository>();
      services.AddTransient<IOrderlineRepository, OrderlineRepository>();

      services.AddSingleton<IConfiguration>(Configuration);

      services.AddTransient<ITotemService, TotemService>();
      services.AddTransient<IAdjectiefService, AdjectiefService>();
      services.AddTransient<ITotemEntryService, TotemEntryService>();
      services.AddTransient<IDrankService, DrankService>();
      services.AddTransient<IDrankTypeService, DrankTypeService>();
      services.AddTransient<IOrderService, OrderService>();

      services.AddTransient<IPaginationMetaDataService, PaginationMetaDataService>();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

      app.UseCors(builder =>
      {
        builder.WithOrigins("http://staging.admin.dekangoeroes.be", "http://staging.totems.dekangoeroes.be")
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
          var response = new ApiServerErrorResponse("Er heeft zich een onverwachte fout voorgedaan. Probeer het later opnieuw.");
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

      // Swagger middleware toevoegen om JSON endpoint te exposen
      app.UseSwagger();

      // Swagger middleware om UI endpoint te exposen
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kangoeroes API - V1");
      });

      app.UseMvcWithDefaultRoute();
    }
  }
}
