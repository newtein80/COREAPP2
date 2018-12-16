using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using COREAPP2.Persistence.Identity;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args)
                        .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    //var catalogContext = services.GetRequiredService<CatalogContext>();
                    //CatalogContextSeed.SeedAsync(catalogContext, loggerFactory).Wait();

                    //var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var RoleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
                    var UserManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    IdentitySeed.IdentitySeedAsync(UserManager, RoleManager).Wait();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
