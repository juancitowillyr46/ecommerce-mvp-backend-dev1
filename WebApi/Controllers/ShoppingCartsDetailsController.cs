using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsDetailsController : ControllerBase
    {
        private readonly IShoppingCartsDetailRepository _shoppingCartsDetailRepository;
        private readonly IMapper _mapper;
        
        public ShoppingCartsDetailsController(IShoppingCartsDetailRepository shoppingCartsDetailRepository, IMapper mapper)
        {
            _shoppingCartsDetailRepository = shoppingCartsDetailRepository;
            _mapper = mapper;
        }

        [HttpPost("")]
        public ActionResult<ShoppingCart> AddItemToShoppintCart(ShoppingCartDetailCreate shoppingCartDetailCreate)
        {
            var shoppingCartDetail = _mapper.Map<ShoppingCartDetail>(shoppingCartDetailCreate);   
            _shoppingCartsDetailRepository.CreateDetail(shoppingCartDetail);
            _shoppingCartsDetailRepository.SaveChanges();
            return Ok(shoppingCartDetail);
        }

    }
}