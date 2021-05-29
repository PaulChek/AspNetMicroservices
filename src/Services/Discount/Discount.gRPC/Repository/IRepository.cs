using Discount.gRPC.Model;
using System.Threading.Tasks;

namespace Discount.gRPC.Repository {
    public interface IRepository {
        Task<CouponModel> GetAsync(string productName);
        Task<bool> CreateAsync(CouponModel coupon);
        Task<bool> DeleteAsync(string productName);
    }
}
