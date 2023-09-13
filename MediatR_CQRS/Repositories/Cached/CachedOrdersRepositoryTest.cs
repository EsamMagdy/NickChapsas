using MediatR_CQRS.Dtos;

namespace MediatR_CQRS.Repositories.Cached
{
    public class CachedOrdersRepositoryTest : IOrderRepository
    {
        private readonly IOrderRepository _orderRepository;

        public CachedOrdersRepositoryTest(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> CreateOrder(OrderDto order)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDto>> GetAllOrdres()
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDto> GetOrderByID(int id)
        {
            throw new NotImplementedException();
        }
    }

}
