using MediatR_CQRS.Context;
using MediatR_CQRS.Data;
using MediatR_CQRS.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MediatR_CQRS.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        /*
            to add cachsing layer, add private readonly ConcreateDictionary 
            then add some logic in GetAllOrders
        */
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<OrderDto> CreateOrder(OrderDto orderDto)
        {
            Order order = new() { Name = orderDto.Name };

            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            orderDto.Id = order.Id;

            return orderDto;
        }

        public async Task<List<OrderDto>> GetAllOrdres()
        {
            return (await _context.Orders.ToListAsync())
                            .Select(o => new OrderDto() { Id = o.Id, Name = o.Name })
                            .ToList();
        }

        public async Task<OrderDto> GetOrderByID(int id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return null;
            }

            return new OrderDto { Id = order.Id, Name = order.Name };
        }
    }
}
