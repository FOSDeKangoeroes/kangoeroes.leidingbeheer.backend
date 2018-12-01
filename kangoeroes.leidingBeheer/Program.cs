using System.IO;
using kangoeroes.leidingBeheer.Data.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace kangoeroes.leidingBeheer
{
  public class Program
  {
    public static void Main(string[] args)
    {
      BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args)
    {
      var host = WebHost.CreateDefaultBuilder(args)
        .UseKestrel()
        .UseUrls("http://+:5000")
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();

      using (var scope = host.Services.CreateScope())
      {
        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
        context.Database.Migrate();
      }

      return host;
    }
  }
}
