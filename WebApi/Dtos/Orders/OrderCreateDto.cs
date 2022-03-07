using System.Text.Json.Serialization;

namespace WebApi.Dtos.Orders
{
    public class OrderCreateDto
    {
        public int ShoppingCartId { get; set; }
        public int PaymentMethodId { get; set; }

        [JsonIgnore]
        public string IpAddress { get; set; }
    }
}