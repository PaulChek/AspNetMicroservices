using System.Threading.Tasks;
using AspnetRunBasics.Models;
namespace AspnetRunBasics.Services.Interfaces {

    public interface ICartService {
        Task<AspnetRunBasics.Models.CartModel> GetCartAsync(string userId);
        Task<AspnetRunBasics.Models.CartModel> UpdateAsync(AspnetRunBasics.Models.CartModel cart);
        Task CheckOut(CartCheckoutModel order);
    }
}
