using MediatR;
using MediatR_CQRS.Dtos;

namespace MediatR_CQRS.Queries
{
    public class GetlAllOrdersQueries : IRequest<List<OrderDto>>
    {
    }
}
