using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Shop.Agregator.Services {
    public class CartService : ICartService {


        private readonly HttpClient _client;

        public CartService(HttpClient client) {
            _client = client;
        }

        public async Task CheckOut(CartCheckoutModel order) {
            await _client.PostAsJsonAsync<CartCheckoutModel>("/cart", order);
        }

        public async Task<CartModel> GetCartAsync(string userId) {
            return await _client.GetFromJsonAsync<CartModel>($"/cart/{userId}");
        }

        public async Task<CartModel> UpdateAsync(CartModel cart) {
            var res = await _client.PutAsJsonAsync<CartModel>("/cart", cart);
            return await res.Content.ReadFromJsonAsync<CartModel>();
        }
    }
}
