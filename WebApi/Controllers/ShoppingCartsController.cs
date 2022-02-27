using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController: ControllerBase
    {

        private readonly IShoppingCartsRepository _shoppingCartsRepository;
        private readonly IMapper _mapper;

        public ShoppingCartsController(IShoppingCartsRepository shoppingCartsRepository, IMapper mapper)
        {
            _shoppingCartsRepository = shoppingCartsRepository;
            _mapper = mapper;
        }

        [HttpPost("")]
        public ActionResult<ShoppingCart> CreateShoppingCart(ShoppingCartCreateRequestDto shoppingCartCreateDto)
        {
            decimal totalVentas = 0;

            // TODO: otra reglas comerciales
            ICollection<ShoppingCartDetail> lstCreateModelDetail = new List<ShoppingCartDetail>();
            foreach (var product in shoppingCartCreateDto.Products)
            {
                var subTotal = (product.Quantity * product.Price);
                totalVentas = totalVentas + subTotal;
                var productMapper = _mapper.Map<ShoppingCartDetail>(product);
                productMapper.SubTotal = subTotal;
                lstCreateModelDetail.Add(productMapper);
            }

            // Sum(x => x.Quantity)
            var createModelShoppinCart = new ShoppingCart {
                Code = System.Guid.NewGuid().ToString(),
                QuantityProducts = shoppingCartCreateDto.Products.Count,
                CreatedOn = System.DateTime.Now,
                Total = totalVentas
            };

            _shoppingCartsRepository.CreateShoppingCart(createModelShoppinCart, lstCreateModelDetail);

            return Ok(_mapper.Map<ShoppingCartCreateResponseDto>(createModelShoppinCart));
        }

    }
}