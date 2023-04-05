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
        Task<List<GetUser>> GetListUsers();
        Task<User> AddUser(User user);
    }
}
