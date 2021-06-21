using Shop.Agregator.Model;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Shop.Agregator.Services {
    public class CartService : ICartService {


        private readonly HttpClient _client;

        public CartService(HttpClient client) {
            _client = client;
        }

        public async Task<CartModel> GetCartAsync(string userId) {
            var cart2 = await _client.GetFromJsonAsync<CartModel>($"/cart/{userId}");
            return cart2;
        }
    }
}
