using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using bedayzAPI.Core.Security.Hashing;
using bedayzAPI.Persistence;
using bedayzAPI.Persistence.Contexts;

namespace bedayzAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetService<AppDbContext>())
            {
                //services, paswordhasher ,databaseSeedSonradan eklendi sorun çýkarsa silerek denenecek
                var services = scope.ServiceProvider;
                context.Database.EnsureCreated();
                //
                var passwordHasher = services.GetService<IPasswordHasher>();
                //
                DatabaseSeed.Seed(context, passwordHasher);
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
    }
}
