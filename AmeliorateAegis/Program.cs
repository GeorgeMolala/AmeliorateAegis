using AmeliorateAegis.Data;
using AmeliorateAegis.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis
{
    public class Program
    {
        public static object CentreId { get; internal set; }

        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await ContextSeed.SeedRolesAsync(userManager, roleManager);
                    await ContextSeed.SeedSuperAdminAsync(userManager, roleManager);
                    await ContextSeed.SeedParentAsync(userManager, roleManager);
                    await ContextSeed.SeedTeacherAsync(userManager, roleManager);
                    await ContextSeed.SeedManagerAsync(userManager, roleManager);
                    await ContextSeed.SeedLiasonAsync(userManager, roleManager);
                    await ContextSeed.SeedCoordinatorAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            CreateHostBuilder(args).Build().Run();

            try
            {

                //  Specify a directory name that does not exist for this demo.
                string dir = @"c:\78fe9lk";

                // If this directory does not exist, a DirectoryNotFoundException is thrown
                // when attempting to set the current directory.
                Directory.SetCurrentDirectory(dir);
            }
            catch (DirectoryNotFoundException dirEx)
            {
                // Let the user know that the directory did not exist.
                Console.WriteLine("Directory not found: " + dirEx.Message);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static implicit operator Program(List<Programme> v)
        {
            throw new NotImplementedException();
        }
    }
}
