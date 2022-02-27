using System.Collections.Generic;

namespace WebApi.Data
{
    public interface IShoppingCartsRepository
    {
        ShoppingCart CreateShoppingCart(ShoppingCart shoppingCart, ICollection<ShoppingCartDetail> createModelDetail);
        bool DeleteShoppingCart(int id);
        bool UpdateShoppingCart(int id);
        
    }
}