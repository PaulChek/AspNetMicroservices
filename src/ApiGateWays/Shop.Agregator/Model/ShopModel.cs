using System.Collections.Generic;

namespace Shop.Agregator.Model {
    public class ShopModel {
        public string UserId { get; set; }
        public CartModel CartWithFullProducts { get; set; }
        public List<OrderResponseModel> Orders { get; set; }
    }
}
