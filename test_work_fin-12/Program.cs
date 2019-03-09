using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using test_work_fin_12.Data;
using static test_work_fin_12.Data.Role;

namespace test_work_fin_12 {
    public class Program {
        public static void Main (string[] args) {

            var host = BuildWebHost (args);
            using (var scope = host.Services.CreateScope ()) {
                var services = scope.ServiceProvider;
                try {
                    var context = services.GetService<AppDbContext> ();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>> ();

                    IdentityDataInit.SeedData (roleManager);
                    DbInitializer.Seed(context);
                } catch {
                    //Обработка ошибки
                }
            }
            host.Run ();
        }

        public static IWebHost BuildWebHost (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> ()
            .Build ();
    }
}