using System.Collections.Generic;

namespace WebApi.Dtos.ShoppingCarts
{
    public class ShoppingCartCreateDto
    {
        public int UserId {get; set;}
        public string IpAddress {get; set;}
    }
}