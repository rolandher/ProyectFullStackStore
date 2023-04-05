using AdmonStoreDomain.Entities.Commands;
using AdmonStoreDomain.Entities.Entities;
using AdmonStoreDomain.Entities.Query;

namespace AdmonStore.Domain.Gateway

{
    public interface IUserUseCase
    {
        Task<NewUser> CreateUser(User user);        
        Task<List<User>> GetUsers();       
        Task<User> UpdateUser(User user);
        Task<string> DeleteUser(string id);
    }
}
