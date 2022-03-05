using System.Collections.Generic;

namespace WebApi.Dtos
{
    public class ShoppingCartReadDto
    {
        public int Id { get; set; }
        public string Code { get; set;}

        public List<ShoppingCartDetailReadDto> Items {get; set;}
    }
}