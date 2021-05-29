using MediatR;
using Ordering.App.Contracts.Persistence;
using Ordering.Domain.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.App.Features.Commands {
    public static class UpdateOrder {

        public record Command(Order order) : IRequest;

        public class Handler : IRequestHandler<Command> {

            private readonly IOrderRepository _repo;

            public Handler(IOrderRepository repo) {
                _repo = repo;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken) {
                await _repo.UpdateAsync(request.order);
                return Unit.Value;
            }
        }
    }
}
