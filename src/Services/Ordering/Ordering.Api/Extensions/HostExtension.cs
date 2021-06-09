using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Api.Extensions {
    public static class HostExtension {
        public static IHost MigrateDb<TContext>(this IHost host, int retry = 0, int maxTry = 50) where TContext : DbContext {
            using (var scope = host.Services.CreateScope()) {
                var sp = scope.ServiceProvider;
                var context = sp.GetService<TContext>();

                try {
                    Console.WriteLine($"Start migration {retry}");
                  
                    context.Database.Migrate();

                    Console.WriteLine("Success migration");
                }
                catch (Exception e) {

                    Console.WriteLine($"[ErrorDB_{e.Message}]  try {retry} from {maxTry}");

                    Thread.Sleep(3000);

                    _ = retry < maxTry ? MigrateDb<TContext>(host, retry + 1, maxTry) : null;

                }

            }
            return host;
        }
    }
}
