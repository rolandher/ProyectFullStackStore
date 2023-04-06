using AdmonStore.Domain2.Gateway.Repositories;
using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using AdmonStore.Infrastructure2.SqlAdapter;
using Moq;

namespace StoryRepositoryTest.StoreRepositoryTest
{
    public class StoreRepositoryTest
    {
        private readonly Mock<IStoreRepository> _mockStoreRepository;
        public StoreRepositoryTest()
        {
            _mockStoreRepository = new();
        }

        [Fact]
        public async Task GetStoreAsync()
        {
            //Arrange
            var store = new Store
            {
                Id_User = "123456789",
                Names = "Bodega",
                Description = "Lacteos"

            };
            var storeList = new List<Store> { store };
            _mockStoreRepository.Setup(x => x.GetStoreAsync()).ReturnsAsync(storeList);

            //Act
            var result = await _mockStoreRepository.Object.GetStoreAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(storeList, result);
        }

        [Fact]
        public async Task CreateStoreAsync()
        {
            //Arrange
            var newStore = new Store
            {
                Id_User = "123456789",
                Names = "Bodega",
                Description = "Lacteos"

            };
            var storeCreated = new NewStore
            {
                Id_User = "123456789",
                Names = "Bodega",
                Description = "Lacteos"

            };
            _mockStoreRepository.Setup(x => x.CreateStoreAsync(newStore)).ReturnsAsync(storeCreated);

            //Act
            var result = await _mockStoreRepository.Object.CreateStoreAsync(newStore);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(storeCreated, result);
        }
    }
}