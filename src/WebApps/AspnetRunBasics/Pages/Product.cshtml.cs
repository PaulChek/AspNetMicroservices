using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics {
    public class ProductModel : PageModel {
        private readonly ICartService _cart;
        private readonly ICatalogService _catalog;

        public ProductModel(ICartService cart, ICatalogService catalog) {
            _cart = cart;
            _catalog = catalog;
        }

        public IEnumerable<CatalogModel> ProductList { get; set; } = new List<CatalogModel>();
        public IEnumerable<string> CategoryList { get; set; } = new List<string>();


        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(string category) {
            CategoryList = (await _catalog.GetAllItemsAsync()).Select(v => v.Category);

            if (!string.IsNullOrEmpty(category)) {
                ProductList = (await _catalog.GetAllItemsAsync()).Where(p => p.Category == category);
                SelectedCategory = category;
            }
            else {
                ProductList = await _catalog.GetAllItemsAsync();
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