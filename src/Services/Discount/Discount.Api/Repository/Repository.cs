using Discount.Api.Model;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;
using System.Threading.Tasks;

namespace Discount.Api.Repository {
    public class Repository : IRepository {
        private readonly IConfiguration _configuration;

        public Repository(IConfiguration configuration) {
            _configuration = configuration;
        }

        public async Task<bool> Create(Coupon coupon) {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("PostgerServer"));
            var res = await connection.ExecuteAsync(
                $"INSERT INTO Coupon (ProductName, Description, Amount) VALUES  (@ProductName, @Description, @Amount)",
                new { ProductName = coupon.ProductName, Description = coupon.Description, Amount  = coupon.Amount}
                );
            return res != 0;
        }

        public async Task<bool> Delete(string productName) {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("PostgerServer"));
            var res = await connection.ExecuteAsync(
                "DELETE FROM Coupon WHERE ProductName = ProductName", new { ProductName = productName }
                );
            return res != 0;
        }

        public async Task<Coupon> Get(string productName) {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("PostgerServer"));

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName});

            if (coupon == null) return new Coupon { Description = "No discount for this product" };

            return coupon;
        }
    }
}
