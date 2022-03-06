using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Dtos.ShoppingCartsItems;
using WebApi.Services;
using WebApi.Services.Interface;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsItemsController : ControllerBase
    {
        private readonly IShoppingCartsItemsService _shoppingCartsItemsService;
        private readonly IShoppingCartsService _shoppingCartsService;
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;
        
        public ShoppingCartsItemsController(IShoppingCartsItemsService shoppingCartsItemsService, IMapper mapper, IShoppingCartsService shoppingCartsService, IProductsService productsService)
        {
            _shoppingCartsItemsService = shoppingCartsItemsService;
            _shoppingCartsService = shoppingCartsService;
            _mapper = mapper;
            _productsService = productsService;
        }

        [HttpPost("")]
        public ActionResult<ShoppingCartItemReadDto> AddItem(ShoppingCartItemCreateDto shoppingCartDetailCreate)
        {
            ProductReadDto productReadDto =  _productsService.GetProductById(shoppingCartDetailCreate.ProductId);
            shoppingCartDetailCreate.Price = productReadDto.Price;
            var shoppingCartReadDto = _shoppingCartsItemsService.CreateItem(shoppingCartDetailCreate);

            _shoppingCartsService.UpdateShoppingCart(shoppingCartDetailCreate.ShoppingCartId);

            return Ok(shoppingCartReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, ShoppingCartItemUpdateDto shoppingCartItemUpdateDto)
        {
            var updateSuccess = _shoppingCartsItemsService.UpdateItem(id, shoppingCartItemUpdateDto);

            if(!updateSuccess){
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult RemoveItem(int id)
        {
            if(!_shoppingCartsItemsService.RemoveItem(id))
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}