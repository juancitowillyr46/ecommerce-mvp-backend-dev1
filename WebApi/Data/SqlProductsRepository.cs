using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Data
{
    public class SqlProductsRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public SqlProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product product)
        {
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault<Product>(p => p.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}