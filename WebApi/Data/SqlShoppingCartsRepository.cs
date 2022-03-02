using System.Collections.Generic;
using System.Linq;

namespace WebApi.Data
{
    public class SqlShoppingCartsRepository : IShoppingCartsRepository
    {
        private readonly AppDbContext _context;
        
        public SqlShoppingCartsRepository(AppDbContext context)
        {
            _context = context;
        }

        public ShoppingCart CreateShoppingCart(ShoppingCart shoppingCart)
        {
            var modelCreate = shoppingCart;
            if(shoppingCart != null) {
                _context.ShoppingCarts.Add(shoppingCart);
            }

            return shoppingCart;
        }

        public bool DeleteShoppingCart(int id)
        {
            throw new System.NotImplementedException();
        }

        public ShoppingCart GetShoppingCartById(int id)
        {
           return _context.ShoppingCarts.FirstOrDefault<ShoppingCart>(opt => opt.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public bool UpdateShoppingCart(int id)
        {
           //var shoppingFind =  _context.ShoppingCarts.FirstOrDefault(s => s.Id == id).Id;
           
            throw new System.NotImplementedException();
        }
    }
}