using MediatR;
using MediatR_CQRS.Dtos;
using MediatR_CQRS.Queries;
using MediatR_CQRS.Repositories;

namespace MediatR_CQRS.Handlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetlAllOrdersQueries, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDto>> Handle(GetlAllOrdersQueries request, CancellationToken cancellationToken)
        {

            return await _orderRepository.GetAllOrdres();
          
        }
    }
}
