using System.Collections.Generic;

namespace AspnetRunBasics.Models {
    // public record CartModel(string UserId, List<ItemOfCartExtendedModel> Items, decimal Total);
    public class CartModel {
        public CartModel(string userId, decimal total, List<ItemOfCartExtendedModel> items) {
            UserId = userId;
            Total = total;
            Items = items;
        }

        public string UserId { get; set; }
        public decimal Total { get; set; }

        public List<ItemOfCartExtendedModel> Items { get; set; }
    }
}
