using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("ByCategory/{categoryId}")]
        public ActionResult <IEnumerable<ProductReadDto>> GetAllProducts(int categoryId)
        {
            var productItems = _repository.GetAllProducts(categoryId);
            return Ok(_mapper.Map<List<ProductReadDto>>(productItems));
        }

        [HttpGet("{id}")]
        public ActionResult <ProductReadDetailDto> GetProductById(int id)
        {
            var productItem = _repository.GetProductById(id);
            return Ok(_mapper.Map<ProductReadDetailDto>(productItem));
        }
    }
}