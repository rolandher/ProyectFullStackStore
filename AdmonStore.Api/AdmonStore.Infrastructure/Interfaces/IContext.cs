using AdmonStore.Infrastructure.Entities;
using MongoDB.Driver;

namespace AdmonStore.Infrastructure.Interfaces
{
    public interface IContext
    {
        public IMongoCollection<UserEntity> Users { get; }
    }
}
