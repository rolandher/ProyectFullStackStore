using AdmonStore.Domain2.Gateway.Repositories;
using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using AdmonStore.Infrastructure2.Gateway;
using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Infrastructure2.SqlAdapter
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;
        private readonly string _tableName = "Locations";

        public LocationRepository(IDbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
        }

        public async Task<NewLocation> CreateLocationAsync(Location location)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var createLocation = new Location
            {
                Id_Store = location.Id_Store,
                Names = location.Names,
                Description = location.Description,
                Location_Type = location.Location_Type

            };

            string sqlQuery = $"INSERT INTO {_tableName} (Id_Store, Names, Description, Location_Type) VALUES (@Id_Store, @Names, @Description, @Location_Type)";
            var result = await connection.ExecuteAsync(sqlQuery, createLocation);
            connection.Close();
            return _mapper.Map<NewLocation>(createLocation);

        }

        public async Task<List<Location>> GetLocationAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {_tableName}";
            var result = await connection.QueryAsync<Location>(sqlQuery);

            connection.Close();
            return result.ToList();

        }
    

    }
}
