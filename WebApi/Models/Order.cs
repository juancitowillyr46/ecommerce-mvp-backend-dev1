using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Order
    {

        [Key]
        public int Id { get; set; }
        public string OrderNumber  { get; set; }
        public int StateId { get; set; }
        public int CustomerId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Total { get; set; }
        public int PaymentMethodId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string IpAddress { get; set; }

        public int ShoppingCartId { get; set;}
        
    }
}