namespace WebApi.Dtos
{
    public class UserResponseLoginDto
    {
        public int Id {get; set;}
        public string Username {get; set;}
        public string Email {get; set;}
        public string Token {get; set;}

        public string FullName {get; set;}

    }
}