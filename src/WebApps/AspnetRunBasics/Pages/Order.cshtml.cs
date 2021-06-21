using AspnetRunBasics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics {
    public class OrderModel : PageModel {
        private readonly IOrderService _order;

        public OrderModel(IOrderService order) {
            _order = order;
        }

        public IEnumerable<Models.OrderResponseModel> Orders { get; set; } = new List<Models.OrderResponseModel>();

        public async Task<IActionResult> OnGetAsync() {
            Orders = await _order.GetOrdersAsync("1");

            return Page();
        }
    }
}