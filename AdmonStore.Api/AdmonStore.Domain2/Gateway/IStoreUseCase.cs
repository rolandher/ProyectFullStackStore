using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Domain2.Gateway
{
    public interface IStoreUseCase
    {
        Task<NewStore> CreateStoreAsync(Store store);
        Task<List<Store>> GetStoreAsync();
    }
}
