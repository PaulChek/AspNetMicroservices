using Application.Features.Orders;
using Application.Features.Orders.Commands;
using AutoMapper;
using EvenetBus.Messges.Events;
using MassTransit;
using MediatR;
using System.Threading.Tasks;

namespace Ordering.Api.EventBusConsumers {
    public class CartCheckOutConsumer : IConsumer<CartCheckOutEvent> {

        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public CartCheckOutConsumer(IMediator mediator, IMapper mapper) {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<CartCheckOutEvent> context) {

            var orderVm = _mapper.Map<OrderVm>(context.Message);

            await _mediator.Send(new CheckOut.Command(orderVm));

            System.Console.WriteLine($"I'm consume something {context.MessageId}");

        }
    }
}
