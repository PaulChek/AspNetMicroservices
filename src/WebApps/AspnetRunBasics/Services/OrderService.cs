using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Shop.Agregator.Services {
    public class OrderService : IOrderService {

        private readonly HttpClient _client;

        public OrderService(HttpClient client) {
            _client = client;
        }
        public async Task<List<OrderResponseModel>> GetOrdersAsync(string userId) {
            return await _client.GetFromJsonAsync<List<OrderResponseModel>>($"/order/{userId}");
        }
    }
}
