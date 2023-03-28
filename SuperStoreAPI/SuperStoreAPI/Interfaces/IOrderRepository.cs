using SuperStore.Data.Models;

namespace SuperStoreAPI.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Guid userId, Order order);
        Order UpdateOrder(Guid userId, Order order);
        Task DeleteOrder(Guid userId, Guid Id);
        Task<Order> GetOrder(Guid userId, Guid Id);
        Task<List<Order>> GetOrders(Guid userId);
        Task SaveAsync();
    }
}
