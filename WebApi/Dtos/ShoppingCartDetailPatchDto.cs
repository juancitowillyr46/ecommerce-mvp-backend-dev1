using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class ShoppingCartDetailPatchDto
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}