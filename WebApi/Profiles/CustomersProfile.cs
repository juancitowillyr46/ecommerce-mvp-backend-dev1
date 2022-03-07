using AutoMapper;
using WebApi.Customers;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Customer, CustomerReadDto>();
        }
    }
}