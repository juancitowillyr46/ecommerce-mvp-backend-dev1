using System.Collections.Generic;

namespace WebApi.Data
{
    public interface IShoppingCartsItemsRepository
    {

        void CreateItem(ShoppingCartItem shoppingCartItem);
        
        ShoppingCartItem GetItemByShoppingCartIdAndProductId(int shoppingCartId, int productId);

        ShoppingCartItem GetItemById(int id);

        List<ShoppingCartItem> GetItemsByShoppingCartId(int shoppingCartId);

        void UpdateItem(ShoppingCartItem shoppingCartItem);

        void DeleteItem(int id);

        bool SaveChanges();
    }
}