using System.IO;
using kangoeroes.infrastructure;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace kangoeroes.webUI
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
        .UseSentry("https://b8009bde08914312bd405a9f464f9376@sentry.io/1337041")
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
