using AdmonStore.Domain.Gateway.Repositories;
using AdmonStore.Infrastructure.Entities;
using AdmonStore.Infrastructure.Interfaces;
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

            public async Task<List<GetUser>> GetListUsers()
            {
                var users = await userCollection.Find(user => true).ToListAsync();
                return _mapper.Map<List<GetUser>>(users);
            }

            public async Task<User> AddUser(User user)
            {
                var userEntity = _mapper.Map<UserEntity>(user);
                await userCollection.InsertOneAsync(userEntity);
                return _mapper.Map<User>(userEntity);
            }

    }      

    
}
