using System.Collections.Generic;

namespace WebApi.Data
{
    public interface IShoppingCartsDetailRepository
    {

        void CreateDetail(ShoppingCartDetail shoppingCartDetail);
        
        ShoppingCartDetail GetShoppingCartDetail(int productId, int shoppingCartId);

        ShoppingCartDetail GetShoppingCartDetailById(int id);

        List<ShoppingCartDetail> GetShoppingItemsByShoppingCartId(int shoppingCartId);

        void UpdateDetail(ShoppingCartDetail shoppingCartDetail);

        void DeleteItem(int id);

        bool SaveChanges();
    }
}