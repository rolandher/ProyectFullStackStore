using AdmonStore.Domain2.Gateway.Repositories;
using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using AdmonStore.Infrastructure2.Gateway;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

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

      

    }
}
