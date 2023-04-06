using AdmonStore.Domain2.Gateway;
using AdmonStore.Domain2.Gateway.Repositories;
using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Domain2.UseCases
{
    public class StoreUseCase : IStoreUseCase
    {
        private readonly IStoreRepository _storeRepository;
        public StoreUseCase(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public async Task<NewStore> CreateStoreAsync(Store store)
        {
            return await _storeRepository.CreateStoreAsync(store);
        }

        public async Task<List<Store>> GetStoreAsync()
        {
            return await _storeRepository.GetStoreAsync();
        }

    }
}
