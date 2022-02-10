
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class User
    {
        [Key]
        public int Id {get; set;}

        [Required]
        public string Email {get; set;}

        [Required]
        public string Username {get; set;}

        [Required]
        public string Password {get; set;}
        
        [Required]
        public DateTime CreateOn {get; set;}

        [Required]
        public Boolean Block {get; set;}
    }
}