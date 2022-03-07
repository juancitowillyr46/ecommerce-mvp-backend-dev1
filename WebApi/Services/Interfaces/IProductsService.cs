using WebApi.Dtos;

namespace WebApi.Services.Interface
{
    public interface IProductsService
    {
        ProductReadDto GetProductById(int id);
    }
}