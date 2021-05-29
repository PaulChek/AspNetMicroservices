using MediatR;
using Ordering.App.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.App.Features.Commands {
    public static class DeleteOrder {
        public record Command(int Id) : IRequest;
        public class Handler:IRequestHandler<Command> {
            private readonly IOrderRepository _repo;

            public Handler(IOrderRepository repo) {
                _repo = repo;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken) {
                await _repo.DeletAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}
