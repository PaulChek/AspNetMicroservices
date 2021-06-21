using AspnetRunBasics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunBasics {
    public class CartModel : PageModel {
        private readonly ICartService _cart;

        public CartModel(ICartService cart) {
            _cart = cart;
        }

        public Models.CartModel Cart { get; set; } = new Models.CartModel(null, 0.0m, new System.Collections.Generic.List<Models.ItemOfCartExtendedModel>());

        public async Task<IActionResult> OnGetAsync() {
            Cart = await _cart.GetCartAsync("1");

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string cartItemId) {
            var cart = await _cart.GetCartAsync("1");
            cart.Items = cart.Items.Where(i => i.Id != cartItemId).ToList();
            await _cart.UpdateAsync(cart);
            return RedirectToPage();
        }
    }
}