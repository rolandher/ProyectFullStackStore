using AdmonStore.Domain2.Gateway;
using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdmonStore.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        private readonly ILocationUseCase _locationUseCase;
        private readonly IMapper _mapper;


        public LocationController(ILocationUseCase locationUseCase, IMapper mapper)
        {
            _locationUseCase = locationUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<NewLocation> CreateStoreAsync([FromBody] NewLocation newLocation)
        {
            return await _locationUseCase.CreateLocationAsync(_mapper.Map<Location>(newLocation));
        }

        [HttpGet]
        public async Task<List<Location>> GetLocationAsync()
        {
            return await _locationUseCase.GetLocationAsync();
        }

    }
}
