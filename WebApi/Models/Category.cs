using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{   
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name {get; set;}
        
        [Required]
        public string Description {get; set;}
        
        [Required]
        public string Image {get; set;}

        public ICollection<Product> Products { get; set; }
    }
}