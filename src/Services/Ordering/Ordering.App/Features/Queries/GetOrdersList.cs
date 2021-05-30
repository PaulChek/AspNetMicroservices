using MediatR;
using Ordering.App.Contracts.Persistence;
using Ordering.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.App.Features.Queries {
    public static class GetOrdersList {
        public record Query(string userName) : IRequest<Response>;
        
        public record Response(IReadOnlyList<Order> orders);
        public class Handler : IRequestHandler<Query, Response> {

            private readonly IOrderRepository _repo;

            public Handler(IOrderRepository repo) {
                _repo = repo;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken) {
                return new Response(await _repo.GetAsync(request.userName));
            }
        }
    }
}
