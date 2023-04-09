using AdmonStore.Domain2.Gateway.Repositories;
using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryRepositoryTest.AdmonRepositoryTest
{
    public class LocationRepositoryTest
    {
        private readonly Mock<ILocationRepository> _mockLocationRepository;
        public LocationRepositoryTest()
        {
            _mockLocationRepository = new();
        }

        [Fact]
        public async Task GetLocationAsync()
        {
            //Arrange
            var location = new Location
            {
                Id_Store = 1,
                Names = "Bodega",
                Description = "Lacteos",
                Location_Type = "Bodega",

            };
            var locationList = new List<Location> { location };
            _mockLocationRepository.Setup(x => x.GetLocationAsync()).ReturnsAsync(locationList);

            //Act
            var result = await _mockLocationRepository.Object.GetLocationAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(locationList, result);
        }

        [Fact]
        public async Task CreateLocationAsync()
        {
            //Arrange
            var newLocation = new Location
            {
                Id_Store = 1,
                Names = "Bodega",
                Description = "Lacteos",
                Location_Type = "Bodega",

            };
            var locationCreated = new NewLocation
            {
                Id_Store = 1,
                Names = "Bodega",
                Description = "Lacteos",
                Location_Type = "Bodega",

            };
            _mockLocationRepository.Setup(x => x.CreateLocationAsync(newLocation)).ReturnsAsync(locationCreated);

            //Act
            var result = await _mockLocationRepository.Object.CreateLocationAsync(newLocation);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(locationCreated, result);
        }

        [Fact]
        public async Task GetLocationByIdAsync()
        {
            //Arrange
            var location = new Location
            {
                Id_Store = 1,
                Names = "Bodega",
                Description = "Lacteos",
                Location_Type = "Bodega",
            };
            var locationId = new Location();
            _mockLocationRepository.Setup(x => x.GetLocationByIdAsync(1)).ReturnsAsync(locationId);

            //Act
            var result = await _mockLocationRepository.Object.GetLocationByIdAsync(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(locationId, result);
        }


    }
}
