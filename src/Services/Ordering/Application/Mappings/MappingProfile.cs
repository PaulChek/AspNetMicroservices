using Application.Features.Orders;
using AutoMapper;
using Domain.Model;

namespace Application.Mappings {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Order, OrderVm>().ReverseMap();
        }
    }
}
