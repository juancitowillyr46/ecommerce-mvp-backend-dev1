using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data
{
    public class SqlOrdersRepository : IOrdersRepository
    {

        private readonly AppDbContext _context;
        
        public SqlOrdersRepository(AppDbContext context)
        {
            _context = context;
        }

        public Order CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            return order;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}