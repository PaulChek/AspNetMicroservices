using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics {
    public class CheckOutModel : PageModel {
        private readonly ICartService _cart;
        private readonly IOrderService _order;

        public CheckOutModel(ICartService cart, IOrderService order) {
            _cart = cart;
            _order = order;
        }

        [BindProperty]
        public Models.CartCheckoutModel Order { get; set; }

        public Models.CartModel Cart { get; set; } = new Models.CartModel(null, 0.0m, new List<ItemOfCartExtendedModel>());

        public async Task<IActionResult> OnGetAsync() {
            Cart = await _cart.GetCartAsync("1");
            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync() {
            Cart = await _cart.GetCartAsync("1");

            if (!ModelState.IsValid) {
                return Page();
            }

            Order.UserName = "1";
            Order.TotalPrice = Cart.Total;

            await _cart.CheckOut(Order);

            return RedirectToPage("Confirmation", "OrderSubmitted");
        }
    }
}