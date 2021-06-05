using Application.Contracts_Interfaces;
using Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands {
    public static class Delete {
        public record Command(int Id) : IRequest<Response>;
        public record Response(bool Res);

        public class Handler : IRequestHandler<Command, Response> {
            private readonly IOrderRepository _repo;

            public Handler(IOrderRepository repo) {
                _repo = repo;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken) {
                var order = await _repo.GetByIdAsync(request.Id);

                if (order == default)
                    throw new NotFoundException("Order Delete", request.Id);

                await _repo.DeleteAsync(order);
                return new Response(true);
            }
        }
    }
}

