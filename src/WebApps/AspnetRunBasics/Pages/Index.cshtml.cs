using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics.Pages {
    public class IndexModel : PageModel {
        private readonly ICatalogService _catalog;
        private readonly ICartService _cart;

        public IndexModel(ICatalogService catalog, ICartService cart) {
            _catalog = catalog;
            _cart = cart;
        }

        public IEnumerable<CatalogModel> ProductList { get; set; } = new List<CatalogModel>();

        public async Task<IActionResult> OnGetAsync() {
            ProductList = await _catalog.GetAllItemsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId) {
            var product = await _catalog.GetItemByIdAsync(productId);
            var cart = await _cart.GetCartAsync("1");
            cart.Items.Add(new ItemOfCartExtendedModel {
                Price = product.Price,
                Category = product.Category,
                Img = product.Img,
                quantity = 1
            });
            await _cart.UpdateAsync(cart);
            return RedirectToPage("Cart");
        }
    }
}
