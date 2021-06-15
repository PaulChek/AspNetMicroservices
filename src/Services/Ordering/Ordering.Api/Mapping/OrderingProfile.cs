using AutoMapper;
using EvenetBus.Messges.Events;
using Application.Features.Orders;

namespace Ordering.Api.Mapping {
    public class OrderingProfile : Profile {
        public OrderingProfile() {
            CreateMap<OrderVm, CartCheckOutEvent>().ForMember(d => d.Id, o => o.Ignore());
            CreateMap<CartCheckOutEvent, OrderVm>().ForMember(d => d.Id, o => o.Ignore());
        }
    }
}
