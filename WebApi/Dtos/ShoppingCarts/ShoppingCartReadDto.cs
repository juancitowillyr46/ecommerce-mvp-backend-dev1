using System.Collections.Generic;
using WebApi.Dtos.ShoppingCartsItems;

namespace WebApi.Dtos.ShoppingCarts
{
    public class ShoppingCartReadDto
    {
        public int Id { get; set; }
        public string Code { get; set;}

        public List<ShoppingCartItemReadDto> Items {get; set;}

        public ShoppingCartReadDto()
        {
            Items = new List<ShoppingCartItemReadDto>();
        }
    }
}