using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Agregator.Model;
using Shop.Agregator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Agregator.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase {

        private readonly ICartService _cartService;

        private readonly IOrderService _orderService;

        private readonly ICatalogService _catalogService;

        public ShopController(ICartService cartService, IOrderService orderService, ICatalogService catalogService) {
            _cartService = cartService;
            _orderService = orderService;
            _catalogService = catalogService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ShopModel>> GetAsync(string userId) {
            var shop = new ShopModel();
            var cart = await _cartService.GetCartAsync(userId);

            foreach (var item in cart.Items) {
                var product = await _catalogService.GetItemByIdAsync(item.Id);
                var extItem = new ItemOfCartExtendedModel() { Quantity = item.Quantity, Category = product.Category, Description = product.Description, Id = item.Id, Img = item.Img, Name = product.Summary, Summary = product.Summary, Price = item.Price };
                shop.CartWithFullProducts.Items.Add(extItem);
            }

            shop.Orders = await _orderService.GetOrdersAsync(userId);
            shop.UserId = userId;

            return Ok(shop);
        }
    }
}
