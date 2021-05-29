using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace Discount.gRPC.Extensions {
    public static class Ex {
        public static async Task MigrateDatabaseAsync<T>(this IHost host, int retry = 0) {

            using (var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();
                var log = services.GetRequiredService<ILogger<T>>();

                try {
                    Console.WriteLine("Migtation of Discounts Db started:");
                    if (retry == 0) throw new NpgsqlException("It's just false alarm))) for checking catch block");      //throw
                    using var connection = new NpgsqlConnection(configuration.GetValue<string>("PostgerServer"));
                    connection.Open();

                    using var command = new NpgsqlCommand(null, connection);
                    command.CommandText = "DROP TABLE IF EXISTS Coupon";
                    command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE Coupon(Id Serial Primary Key, " +
                        "ProductName varchar(24) not null," +
                        "Description varchar(150), " +
                        "Amount Int)";
                    command.ExecuteNonQuery();

                }
                catch (NpgsqlException e) {

                    log.LogError(e.Message);
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    if (retry < 5)
                        _ = MigrateDatabaseAsync<T>(host, retry + 1);
                }

            }

            //return host;

        }
    }
}
