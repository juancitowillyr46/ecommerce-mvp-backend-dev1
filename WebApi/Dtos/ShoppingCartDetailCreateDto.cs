namespace WebApi.Dtos
{
    public class ShoppingCartDetailCreate
    {
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price {get; set;}
    }
}
