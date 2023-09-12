using MediatR;
using MediatR_CQRS.Commands;
using MediatR_CQRS.Dtos;
using MediatR_CQRS.Queries;
using MediatR_CQRS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatR_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOrderRepository _orderRepository;
        public OrdersController(IMediator mediator, IOrderRepository orderRepository)
        {
            _mediator = mediator;
            _orderRepository = orderRepository;
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            //var orders = await _orderRepository.GetAllOrdres();

            var query = new GetlAllOrdersQueries();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("GetOrderById")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            //var order = await _orderRepository.GetOrderByID(id);
            var query = new GetOrderByIdQuery(id);

            var order = await _mediator.Send(query);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            //await _orderRepository.CreateOrder(orderDto);

            var order = await _mediator.Send(command);
            return Ok(order);
        }
    }
}
