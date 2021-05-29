using Cart.Api.Model;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cart.Api.Repository {
    public class Repository : IRepository {
        private readonly IDistributedCache _redisCache;

        public Repository(IDistributedCache redisCache) {
            _redisCache = redisCache;
        }
        public async Task<ShoppingCart> Get(string UserId) {
            var cartString = await _redisCache.GetStringAsync(UserId);
            if (string.IsNullOrEmpty(cartString))
                return new ShoppingCart();
            var cart = JsonSerializer.Deserialize<ShoppingCart>(cartString);
            return cart;
        }

        public async Task Delete(string UserId) {
            await _redisCache.RemoveAsync(UserId);
        }


        public async Task<ShoppingCart> Update(ShoppingCart cart) {
            await _redisCache.SetStringAsync(cart.UserId, JsonSerializer.Serialize(cart));
            return await Get(cart.UserId);
        }
    }
}
