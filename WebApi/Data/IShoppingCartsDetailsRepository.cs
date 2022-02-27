namespace WebApi.Data
{
    public interface IShoppingCartsDetailRepository
    {

        void CreateDetail(ShoppingCartDetail shoppingCartDetail);
        
        ShoppingCartDetail GetShoppingCartDetail(int productId, int shoppingCartId);

        void UpdateDetail(ShoppingCartDetail shoppingCartDetail);

        bool SaveChanges();
    }
}