using AutoMapper;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Services.Interface;

namespace WebApi.Services
{
    public class ProductsService : IProductsService
    {   
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        
        public ProductsService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ProductReadDto GetProductById(int id)
        {
            var productModel = _productRepository.GetProductById(id);
            return _mapper.Map<ProductReadDto>(productModel);
        }
    }
}