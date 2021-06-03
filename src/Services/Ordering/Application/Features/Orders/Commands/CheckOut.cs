using Application.Contracts_Interfaces;
using Application.Features.Orders;
using Application.Model;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands {
    public static class CheckOut {

        public record Command(OrderVm OrderVm) : IRequest<Response>;
        public record Response(int OrderId);

        public class Handler : IRequestHandler<Command, Response> {
            private readonly IOrderRepository _repo;
            private readonly IMapper _mapper;
            private readonly IEmailService _mail;

            public Handler(IOrderRepository repo, IMapper mapper, IEmailService mail) {
                _repo = repo;
                _mapper = mapper;
                _mail = mail;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken) {

                var order = _mapper.Map<Domain.Model.Order>(request.OrderVm);

                var OrderId = (await _repo.AddAsync(order)).Id;

                await SendMailAsync(request.OrderVm);

                return new Response(OrderId);
            }

            private async Task SendMailAsync(OrderVm orderVm) {
                var email = new Email() { To = "paulchek777@gmail.com", Body = $"Order {orderVm.Id} was created.", Subject = "Order was created" };

                try {
                    await _mail.SendMail(email);
                }
                catch (Exception ex) {
                    Console.WriteLine($"[MAIL_ERROR] Order {orderVm.Id} failed due to an error with the mail service: {ex.Message}");
                }
            }
        }
    }
}
