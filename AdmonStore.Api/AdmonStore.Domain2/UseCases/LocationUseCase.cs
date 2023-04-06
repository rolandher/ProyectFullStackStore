using AdmonStore.Domain2.Gateway;
using AdmonStore.Domain2.Gateway.Repositories;
using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Domain2.UseCases
{
    public class LocationUseCase : ILocationUseCase
    {
        private readonly ILocationRepository _locationRepository;
        public LocationUseCase(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task<NewLocation> CreateLocationAsync(Location location)
        {
            return await _locationRepository.CreateLocationAsync(location);
        }

        public async Task<List<Location>> GetLocationAsync()
        {
            return await _locationRepository.GetLocationAsync();
        }
    }
}
