using Discount.gRPC.Repository;
using Grpc.Core;
using System.Threading.Tasks;
using Discount.gRPC.Extensions;

namespace Discount.gRPC.Services {
    public class DiscountServiceImp : DiscountService.DiscountServiceBase {
        private readonly IRepository _repo;

        public DiscountServiceImp(IRepository repo) {
            _repo = repo;
        }

        public override async Task<Response> Get(Request request, ServerCallContext context) {
            var cM = await _repo.GetAsync(request.ProductName);
            return new Response { Coupon = cM.ConvertToCouponGrpc() };
        }

        public override async Task<ResponseBool> Create(Coupon request, ServerCallContext context) {
            var res = await _repo.CreateAsync(request.CouponModel());
            return new ResponseBool { Success = res };
        }
        public override async Task<ResponseBool> Delete(Request request, ServerCallContext context) {
            var res = await _repo.DeleteAsync(request.ProductName);
            return new ResponseBool { Success = res };
        }
    }
}
