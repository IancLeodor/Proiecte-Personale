using SuperStore.Data.Models;
using System;
using System.Collections.Generic;

namespace SuperStoreAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(Guid userId);
        Task<List<User>> GetUsers();
        Task<User> AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid userId);
        Task SaveAsync();
    }
}
