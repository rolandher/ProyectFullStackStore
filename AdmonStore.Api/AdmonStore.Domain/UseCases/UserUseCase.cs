using AdmonStore.Domain.Gateway;
using AdmonStore.Domain.Gateway.Repositories;
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

        public async Task<List<GetUser>> GetListUsers()
        {
            return await _userRepository.GetListUsers();
        }

        public async Task<User> AddUser(User user)
        {
            return await _userRepository.AddUser(user);
        }

    }
}
