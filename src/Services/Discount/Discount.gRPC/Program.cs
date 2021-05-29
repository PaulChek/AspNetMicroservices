using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Discount.gRPC.Extensions;

namespace Discount.gRPC {
    public class Program {
        public static async System.Threading.Tasks.Task Main(string[] args) {

            var host = CreateHostBuilder(args).Build();

           // await host.MigrateDatabaseAsync<Program>();

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
