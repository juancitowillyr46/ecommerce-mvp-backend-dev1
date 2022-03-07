using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICustomersRepository 
    {
        Customer GetCustomerById(int id);
    }
}