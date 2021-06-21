using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Shop.Agregator.Services {
    public class CatalogService : ICatalogService {

        private readonly HttpClient _client;

        public CatalogService(HttpClient client) {
            _client = client;
        }
        public async Task<List<CatalogModel>> GetAllItemsAsync() {
            return await _client.GetFromJsonAsync<List<CatalogModel>>("/product");

        }

        public async Task<CatalogModel> GetItemByIdAsync(string id) {
            return await _client.GetFromJsonAsync<CatalogModel>($"/product/{id}");
        }
    }
}
