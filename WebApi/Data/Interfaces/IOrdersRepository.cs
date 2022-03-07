using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IOrdersRepository
    {
        Order CreateOrder(Order order);
        bool SaveChanges();
    }
}