using AutoMapper;
using SuperStore.Data.Models;
using SuperStoreAPI.Interfaces;
using SuperStoreAPI.Views;

namespace SuperStoreAPI.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderView> AddOrder(Guid userId, OrderForCreationUpdateView orderForCreationUpdateView)
        {
            var orderModel = _mapper.Map<Order>(orderForCreationUpdateView);
            await _orderRepository.AddOrder(userId, orderModel);
            await _orderRepository.SaveAsync();
            return _mapper.Map<OrderView>( await GetOrder(userId,orderModel.Id));
        }

        public async Task<OrderView> Update(Guid userId, OrderForCreationUpdateView orderForCreationUpdateView)
        {
            var order = await _orderRepository.GetOrder(userId, orderForCreationUpdateView.Id);
            _mapper.Map(orderForCreationUpdateView, order);
            await _orderRepository.SaveAsync();
            return _mapper.Map<OrderView>(order);
        }

        public async Task<OrderView> GetOrder(Guid userId, Guid Id)
        {
            var order = await _orderRepository.GetOrder(userId, Id);
            return _mapper.Map<OrderView>(order);
        }
        public async Task<List<OrderView>> GetOrders(Guid userId)
        {
            var orders = await _orderRepository.GetOrders(userId);
            return _mapper.Map<List<OrderView>>(orders);
        }
        public async Task Delete(Guid userId, Guid Id)
        {
           await _orderRepository.DeleteOrder(userId, Id);
           await  _orderRepository.SaveAsync();
        }

    }
}
