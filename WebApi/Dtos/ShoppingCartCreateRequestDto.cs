using System.Collections.Generic;

namespace WebApi.Dtos
{
    public class ShoppingCartCreateRequestDto
    {
        public List<ShoppingCartDetailRequestDto> Products {get; set;}
    }
}