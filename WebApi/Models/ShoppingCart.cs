using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace  WebApi.Data
{
    public class ShoppingCart
    {
        //[Required]
        public int Id { get; set; }

        [Required]
        public string Code {get; set;}

        [Required]
        public int QuantityProducts { get; set; }

        [Required]
        public decimal Total {get; set;}

        [Required]
        public DateTime CreatedOn {get; set;}

        public ICollection<ShoppingCartDetail> ShoppingCartsDetails {get; set;}
    }
}