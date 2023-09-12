using MediatR;
using MediatR_CQRS.Dtos;

namespace MediatR_CQRS.Queries
{
    public class GetOrderByIdQuery:IRequest<OrderDto>
    {
        public int Id { get; set; }
        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
