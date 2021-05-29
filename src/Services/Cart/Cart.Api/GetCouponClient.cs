using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discount.gRPC;

namespace Cart.Api {
    public class GetCouponClient {
        private readonly DiscountService.DiscountServiceClient _client;

        public GetCouponClient(DiscountService.DiscountServiceClient client) {
            _client = client;
        }
        public async Task<Coupon> GetCouponAsync(string productName) {
            return (await _client.GetAsync(new Request { ProductName = productName })).Coupon;
        }
    }
}
