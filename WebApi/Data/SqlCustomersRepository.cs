using System.Linq;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Customers
{
    public class SqlCustomersRepository : ICustomersRepository
    {
        private readonly AppDbContext _context;

        public SqlCustomersRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault<Customer>(c => c.Id == id);
        }
    }
}