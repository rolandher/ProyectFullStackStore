using AdmonStore.Domain2.Gateway;
using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace AdmonStore.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {

        private readonly IStoreUseCase _storeUseCase;
        private readonly IMapper _mapper;


        public StoreController(IStoreUseCase storeUseCase, IMapper mapper)
        {
            _storeUseCase = storeUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<NewStore> CreateStoreAsync([FromBody] NewStore newStore)
        {
            return await _storeUseCase.CreateStoreAsync(_mapper.Map<Store>(newStore));
        }

        [HttpGet]
        public async Task<List<Store>> GetStoreAsync()
        {
            return await _storeUseCase.GetStoreAsync();
        }

    }
}
