using AutoMapper;
using SuperStore.Data;
using SuperStore.Data.Models;
using SuperStoreAPI.Interfaces;
using SuperStoreAPI.Views;
using System.Collections.Generic;

namespace SuperStoreAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserView>> GetUsers()
        {
            var user = await _userRepository.GetUsers();
            return _mapper.Map<List<UserView>>(user);
        }

        public async Task<UserView> GetUser(Guid userId)
        {
            var user = await _userRepository.GetUser(userId);
            return _mapper.Map<UserView>(user);
        }

        public async Task<UserView> AddUser(UserCreationView userCreationView)
        {
            var userModel = _mapper.Map<User>(userCreationView);
            var user = await _userRepository.AddUser(userModel);
            await _userRepository.SaveAsync();
            return _mapper.Map<UserView>(user);
        }

        public async Task DeleteUser(Guid userId)
        {
            _userRepository.DeleteUser(userId);
            await _userRepository.SaveAsync();
        }

        public async Task UpdateUser(UserCreationView userView)
        {
            var user = await _userRepository.GetUser(userView.Id);
            _mapper.Map(userView, user);
            await _userRepository.SaveAsync();
        }

    }
}