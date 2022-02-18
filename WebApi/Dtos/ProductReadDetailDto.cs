namespace WebApi.Dtos
{
    public class ProductReadDetailDto
    {
        public int Id { get; set; }
        
        public string Name {get; set;}
        
        public string Description {get; set;}
        
        public string CoveImage {get; set;}

        public decimal Price {get; set;}
    }
}