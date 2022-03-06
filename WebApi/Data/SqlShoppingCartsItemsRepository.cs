using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class SqlShoppingCartsItemsRepository : IShoppingCartsItemsRepository
    {
        private readonly AppDbContext _context;

        public SqlShoppingCartsItemsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateItem(ShoppingCartItem shoppingCartItem)
        {
            _context.ShoppingCartsItems.Add(shoppingCartItem);
        }

        public ShoppingCartItem GetItemByShoppingCartIdAndProductId(int shoppingCartId, int productId)
        {
            var findItemProduct = _context.ShoppingCartsItems
                                        .FirstOrDefault(s => s.ProductId == productId && 
                                                             s.ShoppingCartId == shoppingCartId);
            return findItemProduct;
        }

        public ShoppingCartItem GetItemById(int id)
        {
            return _context.ShoppingCartsItems.FirstOrDefault(s => s.Id == id);
        }

        public List<ShoppingCartItem> GetItemsByShoppingCartId(int shoppingCartId)
        {
            return _context.ShoppingCartsItems.Include(i => i.Product).Where(i => i.ShoppingCartId == shoppingCartId).ToList<ShoppingCartItem>();
        }

        public void UpdateItem(ShoppingCartItem shoppingCartItem)
        {
            //SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var getShoppingItem = GetItemById(id);
            _context.ShoppingCartsItems.Remove(getShoppingItem);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
        
    }
}