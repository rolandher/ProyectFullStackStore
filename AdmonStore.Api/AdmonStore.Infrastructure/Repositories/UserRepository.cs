using AdmonStore.Domain.Gateway.Repositories;
using AdmonStore.Infrastructure.Entities;
using AdmonStore.Infrastructure.Interfaces;
using AdmonStoreDomain.Entities.Commands;
using AdmonStoreDomain.Entities.Entities;
using AdmonStoreDomain.Entities.Query;
using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserEntity> userCollection;
        private readonly IMapper _mapper;

        public UserRepository(IContext context, IMapper mapper)
        {
            userCollection = context.Users;
            _mapper = mapper;
        }

        public async Task<NewUser> CreateUser(User user)
        {
            var userToCreate = _mapper.Map<UserEntity>(user);
            await userCollection.InsertOneAsync(userToCreate);
            return _mapper.Map<NewUser>(user);
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await userCollection.FindAsync(userEntity => true && userEntity.State == true);
            var usersList = _mapper.Map<List<User>>(users.ToList());
            if (usersList.Count == 0)
            {
                throw new ArgumentException("There aren't shops to show.");
            }
            return usersList;
        }

        public async Task<User> UpdateUser(User user)
        {
            var userToUpdate = _mapper.Map<UserEntity>(user);
            var userUpdated = await userCollection.FindOneAndReplaceAsync(userpEntity => userpEntity.User_Id == user.User_Id
                    && userpEntity.State == true, userToUpdate);

            return userUpdated == null
                ? throw new ArgumentException($"There isn't a user with this ID: {user.User_Id}.")
                : _mapper.Map<User>(userToUpdate);
        }

        public async Task<string> DeleteUser(string id)
        {
            var users = await GetUsers();
            var userToDelete = users.FirstOrDefault(usersList => usersList.User_Id == id);
            if (userToDelete != null)
            {
                userToDelete.State = false;
                await UpdateUser(userToDelete);
            }
            else
            {
                throw new ArgumentException($"There isn't a user with this ID: {id}.");
            }
            return $"Delete Successful for ID: {id}";
        }

    }             

}      

    

