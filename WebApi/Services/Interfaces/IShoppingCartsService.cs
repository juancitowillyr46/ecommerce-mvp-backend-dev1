using WebApi.Dtos.ShoppingCarts;

namespace WebApi.Services.Interface
{
    public interface IShoppingCartsService
    {
        ShoppingCartReadDto CreateShoppingCart(ShoppingCartCreateDto shoppingCartCreateDto);

        bool UpdateShoppingCart(int id);

        ShoppingCartReadDto GetShoppingCartById(int id);

        bool ValidateShoppingCartById(int id);
    }
}