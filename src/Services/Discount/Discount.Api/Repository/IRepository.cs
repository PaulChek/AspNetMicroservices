using Discount.Api.Model;
using System.Threading.Tasks;

namespace Discount.Api.Repository {
    public interface IRepository {
        Task<Coupon> Get(string productName);
        Task<bool> Create(Coupon coupon);
        Task<bool> Delete(string productName);
    }
}
