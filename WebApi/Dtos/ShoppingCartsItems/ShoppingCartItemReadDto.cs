namespace WebApi.Dtos.ShoppingCartsItems
{   
    public class ShoppingCartItemReadDto
    {
        public int Id { get; set; }

        public int ProductId { get; set;}

        public string ProductName { get; set;}

        public decimal Total { get; set;}

        public int Quantity { get; set; }
    }
}