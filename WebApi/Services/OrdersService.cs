using System;
using AutoMapper;
using WebApi.Data;
using WebApi.Dtos.Orders;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Services.Interface;
using WebApi.Utilities;
using static WebApi.Utilities.EnumShoppingStates;

namespace WebApi.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly IShoppingCartsRepository _shoppingCartsRepository;
        private readonly IShoppingCartsItemsRepository _shoppingCartsItemsRepository;

        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        
        public OrdersService(IOrdersRepository orderRepository, IMapper mapper, IShoppingCartsItemsRepository shoppingCartsItemsRepository, IShoppingCartsRepository shoppingCartsRepository, IUsersRepository usersRepository)
        {
              _orderRepository = orderRepository;  
              _shoppingCartsItemsRepository = shoppingCartsItemsRepository;
              _shoppingCartsRepository = shoppingCartsRepository;
              _usersRepository = usersRepository;
              _mapper = mapper;
        }

        public OrderReadDto CreateOrder(OrderCreateDto orderCreateDto)
        {

            var itemsModel = _shoppingCartsItemsRepository.GetItemsByShoppingCartId(orderCreateDto.ShoppingCartId);
            decimal totalOrders = 0;
            int productQuantity = 0;
            foreach (var item in itemsModel)
            {
                totalOrders = totalOrders + (item.Price * item.Quantity);
                productQuantity = productQuantity + item.Quantity;
            }

            var shoppingCartModel = _shoppingCartsRepository.GetShoppingCartById(orderCreateDto.ShoppingCartId);

            var userModel = _usersRepository.GetUserById(shoppingCartModel.UserId);

            var orderModel = _mapper.Map<Order>(orderCreateDto);
            orderModel.OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmss");
            orderModel.CustomerId = userModel.Customer.Id;
            orderModel.ProductQuantity = productQuantity;
            orderModel.Total = totalOrders;
            orderModel.StateId = Convert.ToInt32(EnumOrderState.StateId.Confirm);
            orderModel.CreatedOn = DateTime.Now;
            orderModel.IpAddress = orderCreateDto.IpAddress;
            orderModel.ShoppingCartId = orderCreateDto.ShoppingCartId;

            _orderRepository.CreateOrder(orderModel);
            _orderRepository.SaveChanges();

            _shoppingCartsRepository.UpdateStateShoppingCart(orderCreateDto.ShoppingCartId, Convert.ToInt32(EnumShoppingStates.StateId.Confirm));

            return _mapper.Map<OrderReadDto>(orderModel);
        }

    }
}