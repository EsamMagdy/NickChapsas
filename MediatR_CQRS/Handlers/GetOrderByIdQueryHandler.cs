using MediatR;
using MediatR_CQRS.Dtos;
using MediatR_CQRS.Queries;
using MediatR_CQRS.Repositories;
using MediatR_CQRS.Repositories.Cached;

namespace MediatR_CQRS.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;


        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByID(request.Id);

            return order;
        }
    }
}
