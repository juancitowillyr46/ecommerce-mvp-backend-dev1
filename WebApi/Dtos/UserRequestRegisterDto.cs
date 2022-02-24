using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class UserRequestRegisterDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password {get; set;}

    }
}