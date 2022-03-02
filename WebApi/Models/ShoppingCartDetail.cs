using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data
{
    public class ShoppingCartDetail
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int ProductId {get; set;}

        [Required]
        public int Quantity {get; set;}

        [Required]
        public decimal Total {get; set;}

        [Required]
        public int ShoppingCartId {get; set;}

        [Required]
        public decimal Price {get; set;}

        [Required]
        public ShoppingCart ShoppingCart {get; set;}
        public DateTime CreatedOn {get; set;}
        public DateTime UpdatedOn {get; set;}
        public string IpAddress { get; set; }
    }
}