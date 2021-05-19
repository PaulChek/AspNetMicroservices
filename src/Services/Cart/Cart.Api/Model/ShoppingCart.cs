using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Api.Model {
    public class ShoppingCart {
        public ShoppingCart() {
            Items = new List<Item>();
        }

        public ShoppingCart(string userId) : this() {
            UserId = userId;
        }

        public string UserId { get; set; }
        public List<Item> Items { get; set; }
        public decimal Total => Items.Aggregate(0m, (a, c) => a + c.Quantity * c.Price);
    }
}
