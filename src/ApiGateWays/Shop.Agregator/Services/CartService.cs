using Shop.Agregator.Model;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Shop.Agregator.Services {
    public class CartService : ICartService {

        private readonly HttpClient _client;

        public CartService(HttpClient client) {
            _client = client;
        }

        public async Task<CartModel> GetCartAsync(string userId) {
            return await _client.GetFromJsonAsync<CartModel>($"/cart/{userId}");
        }
    }
}
