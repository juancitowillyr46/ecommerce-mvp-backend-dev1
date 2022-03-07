using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Customers;
using WebApi.Dtos.Orders;
using WebApi.Interfaces;
using WebApi.Services.Interface;

namespace  WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        private readonly IShoppingCartsService _shoppingCartsService;

        public OrdersController(IOrdersService ordersService, IShoppingCartsService shoppingCartsService)
        {
            _ordersService = ordersService;
            _shoppingCartsService = shoppingCartsService;
        }

        [HttpPost("")]
        public ActionResult <OrderReadDto> CreateOrder(OrderCreateDto orderCreateDto)
        {
            orderCreateDto.IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var orderReadDto = _ordersService.CreateOrder(orderCreateDto);
            //_shoppingCartsService.UpdateStateShoppingCart(orderCreateDto.ShoppingCartId);
            return Ok(orderReadDto);
        }
    }
}