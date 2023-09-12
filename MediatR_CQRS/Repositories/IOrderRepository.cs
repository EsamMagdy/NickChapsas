using MediatR_CQRS.Context;
using MediatR_CQRS.Dtos;

namespace MediatR_CQRS.Repositories
{
    public interface IOrderRepository
    {
        Task<List<OrderDto>> GetAllOrdres();
        Task<OrderDto> GetOrderByID(int id);
        Task<OrderDto> CreateOrder(OrderDto order);

    }
}
