using System.Collections.Generic;

namespace WebApi.Data
{
    public interface IShoppingCartsRepository
    {
        ShoppingCart CreateShoppingCart(ShoppingCart shoppingCart);
        bool DeleteShoppingCart(int id);
        bool UpdateShoppingCart(int id);
        bool SaveChanges();
        ShoppingCart GetShoppingCartById(int id);
    }
}