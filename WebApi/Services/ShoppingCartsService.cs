using System;
using System.Collections.Generic;
using AutoMapper;
using WebApi.Data;
using WebApi.Dtos.ShoppingCarts;
using WebApi.Dtos.ShoppingCartsItems;
using WebApi.Services.Interface;
using WebApi.Utilities;

namespace WebApi.Services
{
    public class ShoppingCartsService : IShoppingCartsService
    {
        private readonly IShoppingCartsRepository _shoppingCartsRepository;

        private readonly IShoppingCartsItemsRepository _shoppingCartsItemsRepository;
        
        private readonly IMapper _mapper;

        public ShoppingCartsService(IShoppingCartsRepository shoppingCartsRepository, IMapper mapper, IShoppingCartsItemsRepository shoppingCartsItemsRepository)
        {
            _shoppingCartsRepository = shoppingCartsRepository;
            _shoppingCartsItemsRepository = shoppingCartsItemsRepository;
            _mapper = mapper;
        }
        
        public ShoppingCartReadDto CreateShoppingCart(ShoppingCartCreateDto shoppingCartCreateDto)
        {
            var shoppingCartModel = _mapper.Map<ShoppingCart>(shoppingCartCreateDto);
            shoppingCartModel.Code = System.Guid.NewGuid().ToString();
            shoppingCartModel.IpAddress = shoppingCartCreateDto.IpAddress;
            shoppingCartModel.CreatedOn = System.DateTime.Now;
            shoppingCartModel.StateId = Convert.ToInt32(EnumShoppingStates.StateId.Pending);

            _shoppingCartsRepository.CreateShoppingCart(shoppingCartModel);
            _shoppingCartsRepository.SaveChanges();

            return _mapper.Map<ShoppingCartReadDto>(shoppingCartModel);
        }

        public ShoppingCartReadDto GetShoppingCartById(int id)
        {
            var shoppingCartModel = _shoppingCartsRepository.GetShoppingCartById(id);
            var shoppingCartDto = _mapper.Map<ShoppingCartReadDto>(shoppingCartModel);

            var shoppingCartItems = _shoppingCartsItemsRepository.GetItemsByShoppingCartId(shoppingCartModel.Id);
            shoppingCartDto.Items = _mapper.Map<List<ShoppingCartItemReadDto>>(shoppingCartItems);

            return shoppingCartDto;
        }

        public bool UpdateShoppingCart(int id)
        {
            var shoppingCartModel = _shoppingCartsRepository.GetShoppingCartById(id);
            shoppingCartModel.UpdatedOn = System.DateTime.Now;
            return _shoppingCartsRepository.SaveChanges();
        }

        public bool UpdateStateShoppingCart(int id)
        {
            var shoppingCartModel = _shoppingCartsRepository.GetShoppingCartById(id);
            shoppingCartModel.StateId = 1;
            shoppingCartModel.UpdatedOn = System.DateTime.Now;
            return _shoppingCartsRepository.SaveChanges();
        }

        public bool ValidateShoppingCartById(int id)
        {
            var validate = _shoppingCartsRepository.GetShoppingCartById(id);
            return (validate != null);
        }
    }
}