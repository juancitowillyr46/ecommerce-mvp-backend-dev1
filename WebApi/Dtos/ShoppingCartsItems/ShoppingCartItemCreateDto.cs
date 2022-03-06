using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;

namespace WebApi.Dtos.ShoppingCartsItems
{
    public class ShoppingCartItemCreateDto
    {
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        
        [JsonIgnore]
        public decimal Price {get; set;}
        public string IpAddress {get; set;}
    }
}
