using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos.ShoppingCarts;
using WebApi.Services;
using WebApi.Services.Interface;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController: ControllerBase
    {
        private readonly IShoppingCartsService _shoppingCartsService;

        public ShoppingCartsController(IShoppingCartsService shoppingCartsService)
        {
            _shoppingCartsService = shoppingCartsService;
        }

        [HttpPost("")]
        public ActionResult<ShoppingCartReadDto> CreateShoppingCart(ShoppingCartCreateDto shoppingCartCreateDto)
        {
            shoppingCartCreateDto.IpAddress = (shoppingCartCreateDto.IpAddress == "")? Request.HttpContext.Connection.RemoteIpAddress.ToString() : shoppingCartCreateDto.IpAddress;
            var shoppingCartReadDto = _shoppingCartsService.CreateShoppingCart(shoppingCartCreateDto);
            return Ok(shoppingCartReadDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ShoppingCartReadDto> GetShoppingCartById(int id) 
        {   
            if(!_shoppingCartsService.ValidateShoppingCartById(id)){
                return NotFound();
            }
            return Ok(_shoppingCartsService.GetShoppingCartById(id));
        }
    }
}