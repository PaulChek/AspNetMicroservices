using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Ordering.Api.Extensions;
using Ordering.infrastructure.Persistence;

namespace Ordering.Api {
    public class Program {
        public static void Main(string[] args) {

            CreateHostBuilder(args)
                .Build()
                .MigrateDb<OrderContext>((context, service) =>
                    OrderSeed.SeedAsync(context).Wait()
                )
            .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
