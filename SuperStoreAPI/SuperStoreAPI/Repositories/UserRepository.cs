using Microsoft.EntityFrameworkCore;
using SuperStore.Data;
using SuperStore.Data.Models;
using SuperStoreAPI.Interfaces;

namespace SuperStoreAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreContext _context;

        public UserRepository(StoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> GetUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return await _context.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users
                .Include(u => u.Address)
                .OrderBy(u => u.FirstName)
                .ToListAsync();
        }

        public async Task<User> AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.Id = Guid.NewGuid();

            await _context.Users.AddAsync(user);
            return user;
        }
        public void DeleteUser(Guid userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }
            User userRem = _context.Users.Where(a => a.Id == userId).FirstOrDefault();
             _context.Users.Remove(userRem);
        }
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}