using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace AspnetRunBasics {
    public class ProductDetailModel : PageModel {
        private readonly ICatalogService _catalog;
        private readonly ICartService _cart;

        public ProductDetailModel(ICatalogService catalog, ICartService cart) {
            _catalog = catalog;
            _cart = cart;
        }

        public CatalogModel Product { get; set; }

        [BindProperty]
        public string Color { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(string productId) {
            if (string.IsNullOrEmpty(productId)) {
                return NotFound();
            }

            Product = await _catalog.GetItemByIdAsync(productId);
            if (Product == null) {
                return NotFound();
            }
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