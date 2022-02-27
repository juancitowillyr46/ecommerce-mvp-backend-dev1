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
            var shoppingCartMapper = _mapper.Map<ShoppingCart>(shoppingCartCreateDto);
            shoppingCartMapper.Code = System.Guid.NewGuid().ToString();
            shoppingCartMapper.CreatedOn = System.DateTime.Now;
            var getShoppingCart = _shoppingCartsRepository.CreateShoppingCart(shoppingCartMapper);
            _shoppingCartsRepository.SaveChanges();
            return Ok(_mapper.Map<ShoppingCartCreateResponseDto>(shoppingCartMapper));
        }

        // [HttpPut("")]
        // public ActionResult<ShoppingCart> UpdateShoppinCart(ShoppingCartCreateRequestDto shoppingCartCreateDto)
        // {
        //     _shoppingCartsDetailRepository.GetShoppingCartDetail(shoppingCartCreateDto.)
        //     return Ok();
        // }
    }
}