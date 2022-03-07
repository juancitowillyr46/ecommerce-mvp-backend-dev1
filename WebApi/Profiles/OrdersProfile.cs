using AutoMapper;
using WebApi.Customers;
using WebApi.Dtos;
using WebApi.Dtos.Orders;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class OdersProfile : Profile
    {
        public OdersProfile()
        {
            CreateMap<OrderCreateDto, Order>();
            CreateMap<Order, OrderReadDto>();
        }
    }
}