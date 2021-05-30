using MediatR;
using Ordering.App.Contracts.Infrastructure;
using Ordering.App.Contracts.Persistence;
using Ordering.App.Model;
using Ordering.Domain.Model;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.App.Features.Commands {
    public static class CheckOut {

        public record Command(Order order) : IRequest<Response>;

        public record Response(int res);

        public class Handler : IRequestHandler<Command, Response> {

            private readonly IOrderRepository _repo;

            private readonly IEmailService _email;

            public Handler(IOrderRepository repo, IEmailService email) {
                _repo = repo;
                _email = email;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken) {
                var newOrder = await _repo.AddAsync(request.order);

                _ = SendMail(newOrder);
                return new Response(newOrder.Id);
            }

            private async Task SendMail(Order order) {
                var mail = new Email {
                    To = order.EmailAddress,
                    Subject = order.CreatedAt + "Order by" + order.CreatedBy,
                    Body = JsonSerializer.Serialize(order)
                };
                try {
                    await _email.SendEmail(mail);
                }
                catch (Exception) {
                    Console.WriteLine("Get error to send " + order.EmailAddress + "order number " + order.Id);
                }
            }
        }


    }
}
