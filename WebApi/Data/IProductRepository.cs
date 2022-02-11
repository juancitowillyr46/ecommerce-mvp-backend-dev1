using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        void CreateProduct(Product product);
        Product GetProductById(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}