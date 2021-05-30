using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;

namespace Ordering.Api.Extensions {
    public static class HostExtensions {
        public static IHost MigrateDb<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder, int retry = 0)
            where TContext : DbContext {

            using (var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();

                try {
                    Console.WriteLine($"Migrsate db starting  { typeof(TContext).Name }");

                    InvokeSeeder(seeder, context, services);

                    Console.WriteLine($"Migrsate db successfully { typeof(TContext).Name }");
                }
                catch (SqlException e) {
                    Console.WriteLine($"[!] Error: { typeof(TContext).Name } \n {e.Message} retry[{retry}]");
                    if (retry < 15) {
                        Thread.Sleep(2000);
                        MigrateDb<TContext>(host, seeder, retry + 1);
                    }

                }

            }

            return host;
        }

        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services) where TContext : DbContext {
            context.Database.Migrate();                                                         // create db
            seeder(context, services);
        }
    }
}
