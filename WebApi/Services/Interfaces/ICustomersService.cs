using WebApi.Customers;

namespace WebApi.Services.Interface
{
    public interface ICustomersService
    {
        CustomerReadDto GetCustomerById(int id);
    }
}