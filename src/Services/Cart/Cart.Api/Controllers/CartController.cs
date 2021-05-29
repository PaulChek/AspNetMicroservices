using Cart.Api.Model;
using Cart.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase {
        private readonly IRepository _repo;
        private readonly GetCouponClient _grpcClient;

        public CartController(IRepository repo, GetCouponClient grpcClient) {
            _repo = repo;
            _grpcClient = grpcClient;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ShoppingCart>> Get(string userId) {
            var cart = await _repo.Get(userId);
            //grpc client add here
            foreach (var item in cart.Items) {
                var coupon = await _grpcClient.GetCouponAsync(item.Name);
                System.Console.WriteLine("Coupon:->" + coupon.Amount);
                item.Price -= coupon.Amount * item.Quantity;
            }
           
            var newCart = new ShoppingCart(userId) {
                Items = cart.Items
            };

            return Ok(newCart);
        }

        [HttpPut]
        public async Task<ActionResult<ShoppingCart>> Update(ShoppingCart cart) {
            var updCart = await _repo.Update(cart);
            return Ok(updCart);
        }
        [HttpDelete("{userId}")]
        public async Task Delete(string userId) {
            await _repo.Delete(userId);
        }

    }
}
