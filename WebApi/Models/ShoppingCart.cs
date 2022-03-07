using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace  WebApi.Data
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int UserId { get; set; }
        public int StateId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string IpAddress { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartsDetails {get; set;}
    }
}