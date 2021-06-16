using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Agregator.Model {
    public class CartModel {
        public string UserId { get; set; }
        public decimal Total { get; set; }

        public List<ItemOfCartExtendedModel> Items = new List<ItemOfCartExtendedModel>();
    }
}
