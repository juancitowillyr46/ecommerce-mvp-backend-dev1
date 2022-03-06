using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Dtos.ShoppingCartsItems;

namespace WebApi.Services.Interface
{
    public interface IShoppingCartsItemsService
    {
        ShoppingCartItemReadDto CreateItem(ShoppingCartItemCreateDto shoppingCartCreateDto);

        ShoppingCartItemReadDto GetItemById(int id);

        bool UpdateItem(int id, ShoppingCartItemUpdateDto shoppingCartItemUpdateDto);

        ShoppingCartItemReadDto GetItemByShoppingCartIdAndProductId(ShoppingCartItemQueryDto shoppingCartItemQueryDto);

        bool RemoveItem(int id);

    }
}