using System;

namespace WebApi.Models
{
    public class Billing
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string AddressOption2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string IpAddress { get; set; }
        public int OrderId { get; set; }
    }
}