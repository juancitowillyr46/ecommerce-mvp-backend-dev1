using AutoMapper;
using WebApi.Customers;
using WebApi.Interfaces;
using WebApi.Services.Interface;

namespace WebApi.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;

        public CustomersService(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }

        public CustomerReadDto GetCustomerById(int id)
        {
            return _mapper.Map<CustomerReadDto>(_customersRepository.GetCustomerById(id));
        }
    }
}