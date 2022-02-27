using System.Collections.Generic;

namespace WebApi.Dtos
{
    public class ShoppingCartCreateRequestDto
    {
        public int QuantityProducts {get; set;} 
        public decimal Total {get; set;}
    }
}