using AdmonStore.Domain2.Gateway.Repositories;
using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using AdmonStore.Infrastructure2.Gateway;
using AutoMapper;
using Dapper;

namespace AdmonStore.Infrastructure2.SqlAdapter
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;
        private readonly string _tableName = "Stores";

        public StoreRepository(IDbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
        }

        public async Task<NewStore> CreateStoreAsync(Store store)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var storeToCreate = new Store
            {
                Id_User = store.Id_User,
                Names = store.Names,
                Description = store.Description

            };

            Store.Validate(storeToCreate);

            string sqlQuery = $"INSERT INTO {_tableName} (Id_User, Names, Description) VALUES (@Id_User, @Names, @Description )";
            var result = await connection.ExecuteAsync(sqlQuery, storeToCreate);
            connection.Close();
            return _mapper.Map<NewStore>(storeToCreate);

        }

        public async Task<List<Store>> GetStoreAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {_tableName}";
            var stores = await connection.QueryAsync<Store>(sqlQuery);

            connection.Close();
            return stores.ToList();

        }
    }
}
