namespace Discount.gRPC.Extensions {
    public static class ExtensionCoupon {
        public static Coupon ConvertToCouponGrpc(this Discount.gRPC.Model.CouponModel cM) {
            return new Coupon {
                ProductName = cM.ProductName,
                Amount = cM.Amount,
                Description = cM.Description,
                Id = cM.Id
            };

        }
    }
    public static class Exten {
        public static Discount.gRPC.Model.CouponModel CouponModel(this Coupon coupon) {
            return new Discount.gRPC.Model.CouponModel {
                ProductName = coupon.ProductName,
                Amount = coupon.Amount,
                Description = coupon.Description,
                Id = coupon.Id
            };
        }
    }
}
