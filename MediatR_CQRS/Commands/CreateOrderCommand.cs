using MediatR;
using MediatR_CQRS.Dtos;

namespace MediatR_CQRS.Commands
{
    public class CreateOrderCommand:IRequest<OrderDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
