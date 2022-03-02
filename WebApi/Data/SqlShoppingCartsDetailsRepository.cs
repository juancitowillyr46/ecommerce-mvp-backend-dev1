using System.Linq;

namespace WebApi.Data
{
    public class SqlShoppingCartsDetailsRepository : IShoppingCartsDetailRepository
    {
        private readonly AppDbContext _context;

        public SqlShoppingCartsDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateDetail(ShoppingCartDetail shoppingCartDetail)
        {
            _context.ShoppingCartsDetails.Add(shoppingCartDetail);
        }

        public ShoppingCartDetail GetShoppingCartDetail(int productId, int shoppingCartId)
        {
            var findItemProduct = _context.ShoppingCartsDetails
                                        .FirstOrDefault(s => s.ProductId == productId && 
                                                             s.ShoppingCartId == shoppingCartId);
            return findItemProduct;
        }

        public ShoppingCartDetail GetShoppingCartDetailById(int id)
        {
            return _context.ShoppingCartsDetails.FirstOrDefault(s => s.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateDetail(ShoppingCartDetail shoppingCartDetail)
        {
            //SaveChanges();
        }
    }
}