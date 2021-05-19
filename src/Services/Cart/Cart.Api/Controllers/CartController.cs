using Cart.Api.Model;
using Cart.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase {
        private readonly IRepository _repo;

        public CartController(IRepository repo) {
            _repo = repo;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ShoppingCart>> Get(string userId) {
            var cart = await _repo.Get(userId);
            return Ok(cart ?? new ShoppingCart(userId));
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
