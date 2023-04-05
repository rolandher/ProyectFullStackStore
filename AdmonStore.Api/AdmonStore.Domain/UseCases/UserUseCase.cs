using AdmonStore.Domain.Gateway;
using AdmonStore.Domain.Gateway.Repositories;
using AdmonStoreDomain.Entities.Commands;
using AdmonStoreDomain.Entities.Entities;
using AdmonStoreDomain.Entities.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Domain.UseCases
{
    public class UserUseCase : IUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public UserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }       
        public async Task<NewUser> CreateUser(User user)
        {
            return await _userRepository.CreateUser(user);            
        }
        public async Task<User> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);
        }
        public async Task<string> DeleteUser(string id)
        {
            return await _userRepository.DeleteUser(id);
        }
    }
}
