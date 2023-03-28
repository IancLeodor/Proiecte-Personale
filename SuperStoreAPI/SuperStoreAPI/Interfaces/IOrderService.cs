using SuperStoreAPI.Views;

namespace SuperStoreAPI.Interfaces
{
    public interface IOrderService
    {
        Task<OrderView> Update(Guid userId, OrderForCreationUpdateView orderForCreationUpdateView);
        Task<OrderView> GetOrder(Guid userId, Guid Id);
        Task<List<OrderView>> GetOrders(Guid userId);
        Task<OrderView> AddOrder(Guid userId, OrderForCreationUpdateView orderForCreationUpdateView);
        Task Delete(Guid userId, Guid Id);
    }
}
