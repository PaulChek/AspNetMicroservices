using Cart.Api.Model;
using Cart.Api.Repository;
using EvenetBus.Messges.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase {
        private readonly IRepository _repo;
        private readonly GetCouponClient _grpcClient;
        private readonly IPublishEndpoint _publishEndpoint;

        public CartController(IRepository repo, GetCouponClient grpcClient, IPublishEndpoint publishEndpoint) {
            _repo = repo;
            _grpcClient = grpcClient;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet("{userId}")]
        public async Task<ShoppingCart> Get(string userId) {
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

            return newCart;
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

        [HttpPost]
        public async Task<ActionResult> CheckOutAsync([FromBody] CartCheckout checkoutCart) {
            var cart = await Get(checkoutCart.UserId);
            System.Console.WriteLine(cart.UserId);
            if (cart == null) return BadRequest();

            await Delete(checkoutCart.UserId);

            //map
            CartCheckOutEvent messageCheckOut = new CartCheckOutEvent() {
                AddressLine = checkoutCart.AddressLine,
                UserId = checkoutCart.UserId,
                CardName = checkoutCart.CardName,
                CardNumber = checkoutCart.CardNumber,
                Country = checkoutCart.Country,
                CVV = checkoutCart.CVV,
                EmailAddress = checkoutCart.EmailAddress,
                Expiration = checkoutCart.Expiration,
                FirstName = checkoutCart.FirstName,
                LastName = checkoutCart.LastName,
                PaymentMethod = checkoutCart.PaymentMethod,
                State = checkoutCart.State,
                TotalPrice = cart.Total,
                ZipCode = checkoutCart.ZipCode
            };


            await _publishEndpoint.Publish(messageCheckOut);

            return Accepted();
        }

    }
}
