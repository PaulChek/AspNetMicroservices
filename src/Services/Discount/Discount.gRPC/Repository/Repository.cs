using Dapper;
using Discount.gRPC.Model;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Threading.Tasks;

namespace Discount.gRPC.Repository {
    public class Repository : IRepository {
        private readonly IConfiguration _configuration;

        public Repository(IConfiguration configuration) {
            _configuration = configuration;
        }

        public async Task<bool> CreateAsync(CouponModel coupon) {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("PostgerServer"));
            var res = await connection.ExecuteAsync(
                $"INSERT INTO Coupon (ProductName, Description, Amount) VALUES  (@ProductName, @Description, @Amount)",
                new { ProductName = coupon.ProductName, Description = coupon.Description, Amount  = coupon.Amount}
                );
            return res != 0;
        }

        public async Task<bool> DeleteAsync(string productName) {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("PostgerServer"));
            var res = await connection.ExecuteAsync(
                "DELETE FROM Coupon WHERE ProductName = ProductName", new { ProductName = productName }
                );
            return res != 0;
        }

        public async Task<CouponModel> GetAsync(string productName) {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("PostgerServer"));

            var coupon = await connection.QueryFirstOrDefaultAsync<CouponModel>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName});

            if (coupon == null) return new CouponModel {ProductName = productName, Amount = 0 , Description = "No discount for this product" };

            return coupon;
        }
    }
}
