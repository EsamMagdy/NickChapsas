using MediatR;
using MediatR_CQRS.Commands;
using MediatR_CQRS.Dtos;
using MediatR_CQRS.Repositories;

namespace MediatR_CQRS.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return await _orderRepository.CreateOrder(new OrderDto { Id = request.Id, Name = request.Name });
        }
    }
}
