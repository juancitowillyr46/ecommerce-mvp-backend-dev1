using WebApi.Dtos.Orders;

namespace WebApi.Services.Interface
{
    public interface IOrdersService
    {
        OrderReadDto CreateOrder(OrderCreateDto orderCreateDto);
    }
}