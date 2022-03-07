using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{   
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string DocumentNumber {get; set;}
        public string Email {get; set;}
        public string PhoneNumber {get; set;}
        public string Address {get; set;}
        public string AddressOption2 {get; set;}
        public string City { get; set;}
        public string Country { get; set;}
        public int UserId {get; set;}
        
    }
}