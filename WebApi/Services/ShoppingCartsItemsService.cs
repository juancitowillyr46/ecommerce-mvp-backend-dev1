using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Dtos.ShoppingCartsItems;
using WebApi.Services.Interface;

namespace WebApi.Services
{
    public class ShoppingCartsItemsService : IShoppingCartsItemsService
    {
        private readonly IShoppingCartsItemsRepository _shoppingCartsItemsRepository;
        private readonly IMapper _mapper;
        
        public ShoppingCartsItemsService(IShoppingCartsItemsRepository shoppingCartsItemsRepository, IMapper mapper)
        {
            _shoppingCartsItemsRepository = shoppingCartsItemsRepository;
            _mapper = mapper;
        }
        public ShoppingCartItemReadDto CreateItem(ShoppingCartItemCreateDto shoppingCartCreateDto)
        {
            var itemModel = _shoppingCartsItemsRepository.GetItemByShoppingCartIdAndProductId(shoppingCartCreateDto.ShoppingCartId, shoppingCartCreateDto.ProductId);
            
            if(itemModel != null) {

                itemModel.Quantity = itemModel.Quantity + shoppingCartCreateDto.Quantity;
                itemModel.Total = itemModel.Quantity * itemModel.Price;
                itemModel.UpdatedOn = System.DateTime.Now;
                _shoppingCartsItemsRepository.UpdateItem(itemModel);

            } else {

                itemModel = _mapper.Map<ShoppingCartItem>(shoppingCartCreateDto);  
                itemModel.Total = itemModel.Quantity * itemModel.Price;
                itemModel.CreatedOn = System.DateTime.Now;
                _shoppingCartsItemsRepository.CreateItem(itemModel);

            }

            _shoppingCartsItemsRepository.SaveChanges();

            var itemDto = _mapper.Map<ShoppingCartItemReadDto>(itemModel);  

            return itemDto;
        }

        public ShoppingCartItemReadDto GetItemById(int id)
        {   
            return _mapper.Map<ShoppingCartItemReadDto>(_shoppingCartsItemsRepository.GetItemById(id));
        }

        public bool UpdateItem(int id, ShoppingCartItemUpdateDto shoppingCartItemUpdateDto)
        {
            var itemModel = _shoppingCartsItemsRepository.GetItemById(id);
            itemModel.Quantity = itemModel.Quantity + shoppingCartItemUpdateDto.Quantity;
            itemModel.Total = itemModel.Quantity * itemModel.Price;
            itemModel.UpdatedOn = System.DateTime.Now;
            _shoppingCartsItemsRepository.UpdateItem(itemModel);
            return _shoppingCartsItemsRepository.SaveChanges();
        }

        public ShoppingCartItemReadDto GetItemByShoppingCartIdAndProductId(ShoppingCartItemQueryDto shoppingCartItemQueryDto)
        {
            var getItemModel = _shoppingCartsItemsRepository.GetItemByShoppingCartIdAndProductId(shoppingCartItemQueryDto.ShoppingCartId, shoppingCartItemQueryDto.ProductId);
            return _mapper.Map<ShoppingCartItemReadDto>(getItemModel);
        }

        public bool RemoveItem(int id)
        {
            _shoppingCartsItemsRepository.DeleteItem(id);
            return _shoppingCartsItemsRepository.SaveChanges();
        }

    }
}