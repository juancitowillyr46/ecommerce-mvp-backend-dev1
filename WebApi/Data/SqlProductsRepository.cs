using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Product> GetAllProducts(int categoryId)
        {
            // var new_list = from p in db.People
            //        join c in db.Companies on p.Company.Id equals c.Id
            //        select new { p, c };
            
            if(categoryId > 0)
            {
                return _context.Products.Include(p => p.Category).ToList().Where(w => w.CategoryId == categoryId);
            } else 
            {
                return _context.Products.Include(p => p.Category).ToList();
            }
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