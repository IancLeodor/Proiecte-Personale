using Microsoft.EntityFrameworkCore;
using SuperStore.Data;
using SuperStore.Data.Models;
using SuperStoreAPI.Interfaces;

namespace SuperStoreAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext _context;

        public OrderRepository(StoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Order> AddOrder(Guid userId, Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            order.UserId = userId;
            await _context.Orders.AddAsync(order);
            return order;
        }

        public Order UpdateOrder(Guid userId, Order order)
        {
            order.UserId = userId;
            _context.Entry(order).Property(x => x.OrderNumber).IsModified = false;
            _context.Orders.Update(order);
            return _context.Orders.Include(o => o.OrderProducts).ThenInclude(o => o.Product).FirstOrDefault(o => o.Id == order.Id);
        }

        public async Task DeleteOrder(Guid userId, Guid Id)
        {
            var order = _context.Orders.Include(o => o.OrderProducts).FirstOrDefault(o => o.UserId == userId && o.Id == Id);
            if(order != null)
                _context.Orders.Remove(order);
        }

        public async Task<Order> GetOrder(Guid userId, Guid Id)
        {
            return await _context.Orders.Include(o => o.OrderProducts).ThenInclude(o => o.Product).FirstOrDefaultAsync(o => o.UserId == userId && o.Id == Id);
        }

        public async Task<List<Order>> GetOrders(Guid userId)
        {
            return await _context.Orders.Include(o => o.OrderProducts).ThenInclude(o => o.Product).Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
