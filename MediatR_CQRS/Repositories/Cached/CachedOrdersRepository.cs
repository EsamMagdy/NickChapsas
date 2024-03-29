﻿using MediatR_CQRS.Dtos;
using System.Collections.Concurrent;

namespace MediatR_CQRS.Repositories.Cached
{
    public class CachedOrdersRepository : IOrderRepository
    {
        private readonly IOrderRepository _orderRepository;

        private readonly ConcurrentDictionary<int, OrderDto> _cache = new ConcurrentDictionary<int, OrderDto>();
        public CachedOrdersRepository(IOrderRepository orderRepository)
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
            if (_cache.ContainsKey(id))
            {
                return _cache[id];
            }

            var order = await _orderRepository.GetOrderByID(id);

            _cache.TryAdd(id, order);
            return order;
        }
    }
}
