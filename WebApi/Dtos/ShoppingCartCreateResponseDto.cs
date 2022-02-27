namespace WebApi.Dtos
{
    public class ShoppingCartCreateResponseDto
    {
        public int Id { get; set; }
        public string Code {get; set;}

        public decimal Total {get; set;}
    }
}