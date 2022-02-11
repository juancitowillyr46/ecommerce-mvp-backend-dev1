using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public ActionResult <IEnumerable<Product>> GetAllProducts()
        {
            var productItems = _repository.GetAllProducts();
            return Ok(productItems);
        }

        [HttpGet("{id}")]
        public ActionResult <Product> GetProductById(int id)
        {
            var productItem = _repository.GetProductById(id);
            return Ok(productItem);
        }
    }
}