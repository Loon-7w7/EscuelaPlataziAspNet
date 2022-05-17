using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EscuelaPlatazi.Models;

namespace EscuelaPlatazi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Host = CreateHostBuilder(args).Build();

            using (var Scope = Host.Services.CreateScope()) 
            {
                var Services = Scope.ServiceProvider;
                try
                {
                    var Context = Services.GetRequiredService<SchoolContext>();
                    Context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = Services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Ocurrio un error");
                }
                Host.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
