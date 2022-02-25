using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{   
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string FirstName {get; set;}
        
        [Required]
        public string LastName {get; set;}
        
        [Required]
        public string Email {get; set;}

        public string PhoneNumber {get; set;}

        public string Address {get; set;}

        public string AddressOption2 {get; set;}

        // [Required]
        public int UserId {get; set;}
        
    }
}