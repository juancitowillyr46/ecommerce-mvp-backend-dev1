namespace WebApi.Dtos.Orders
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int PaymentMethodId { get; set; }
    }
}