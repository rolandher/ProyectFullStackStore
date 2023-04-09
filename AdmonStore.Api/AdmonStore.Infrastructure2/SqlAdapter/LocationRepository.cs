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
            var locationToCreate = new Location
            {
                Id_Store = location.Id_Store,
                Names = location.Names,
                Description = location.Description,
                Location_Type = location.Location_Type

            };
            Location.Validate(locationToCreate);

            string sqlQuery = $"INSERT INTO {_tableName} (Id_Store, Names, Description, Location_Type) VALUES (@Id_Store, @Names, @Description, @Location_Type)";
            var result = await connection.ExecuteAsync(sqlQuery, locationToCreate);
            connection.Close();
            return _mapper.Map<NewLocation>(locationToCreate);

        }

        public async Task<List<Location>> GetLocationAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {_tableName}";
            var location = await connection.QueryAsync<Location>(sqlQuery);

            connection.Close();
            return location.ToList();

        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {_tableName} WHERE Location_Id = @Location_Id";
            var location = await connection.QueryFirstOrDefaultAsync<Location>(sqlQuery, new { Location_Id = id });

            connection.Close();
            return location;

        }
    }
}
