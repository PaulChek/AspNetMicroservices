using Application.Contracts_Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries {
    public static class GetOrders {

        public record Query(string UserId) : IRequest<Response>;

        public record Response(List<OrderVm> OrdersVm);

        public class Handler : IRequestHandler<Query, Response> {

            private readonly IOrderRepository _repo;
            private readonly IMapper _mapper;

            public Handler(IOrderRepository repo, IMapper mapper) {
                _repo = repo;
                _mapper = mapper;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken) {
                var res = await _repo.GetAllOrdersByUserId(request.UserId);
                var mapped = _mapper.Map<List<OrderVm>>(res);
                return new Response(mapped);
            }
        }
    }
}
