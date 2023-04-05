using AdmonStoreDomain.Entities.Entities;
using AdmonStoreDomain.Entities.Query;

namespace AdmonStore.Domain.Gateway

{
    public interface IUserUseCase
    {
        Task<List<GetUser>> GetListUsers();
        Task<User> AddUser(User user);
    }
}
