using System.Collections.Generic;

namespace WebApi.Data
{
    public class SqlShoppingCartsRepository : IShoppingCartsRepository
    {
        private readonly AppDbContext _context;
        
        public SqlShoppingCartsRepository(AppDbContext context)
        {
            _context = context;
        }

        public ShoppingCart CreateShoppingCart(ShoppingCart shoppingCart, ICollection<ShoppingCartDetail> createModelDetail)
        {
            var modelCreate = shoppingCart;
            if(shoppingCart != null) {
                _context.ShoppingCarts.Add(shoppingCart);
                _context.SaveChanges();

                foreach (var item in createModelDetail)
                {
                    item.ShoppingCartId = shoppingCart.Id;
                    _context.ShoppingCartsDetails.Add(item);
                    //shoppingCart.ShoppingCartsDetails.Add(item);
                    _context.SaveChanges();
                }
                
            }

            return shoppingCart;
        }

        public bool DeleteShoppingCart(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateShoppingCart(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}