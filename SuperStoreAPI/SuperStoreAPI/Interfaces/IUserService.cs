using SuperStore.Data.Models;
using SuperStoreAPI.Views;

namespace SuperStoreAPI.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserView>> GetUsers();
        public Task<UserView> GetUser(Guid id);
        public Task<UserView> AddUser(UserCreationView userCreationView);
        public Task DeleteUser(Guid id);
        public Task UpdateUser(UserCreationView user);
    }
}
