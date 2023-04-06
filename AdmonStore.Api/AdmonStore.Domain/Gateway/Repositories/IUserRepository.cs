using AdmonStoreDomain.Entities.Commands;
using AdmonStoreDomain.Entities.Entities;
using AdmonStoreDomain.Entities.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdmonStore.Domain.Gateway.Repositories
{
    public interface IUserRepository
    {
        Task<NewUser> CreateUser(User user);        
        Task<List<User>> GetUsers();
        Task<User> UpdateUser(User user);
        Task<string> DeleteUser(string id);
    }
}
