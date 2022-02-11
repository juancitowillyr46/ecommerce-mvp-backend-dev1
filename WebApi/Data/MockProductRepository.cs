using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Data
{
    public class MockProductRepository : IProductRepository
    {
        public void CreateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var productsItems = new List<Product> 
            {
                new Product{Id=1, Name="Producto 1", Description="Description 1", CoveImage="image1.png"},
                new Product{Id=2, Name="Producto 2", Description="Description 2", CoveImage="image2.png"},
                new Product{Id=3, Name="Producto 3", Description="Description 3", CoveImage="image3.png"}
            };
            return productsItems;
        }

        public Product GetProductById(int id)
        {
            return new Product{Id=1, Name="Producto 1", Description="Description 1", CoveImage="image1.png"};
        }

        public void UpdateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}