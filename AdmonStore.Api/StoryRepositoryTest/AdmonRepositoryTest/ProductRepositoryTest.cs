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
    public class ProductRepositoryTest
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        public ProductRepositoryTest()
        {
            _mockProductRepository = new();
        }

        [Fact]
        public async Task GetProductAsync()
        {
            //Arrange
            var product = new Product
            {
                Id_Store = 1,
                Names = "Leche",
                Description = "Lacteos",
                Stock = 10,
                Price = 1000,
                AdmissionDate = DateTime.Now,
                DepartureDate = null,
                State = "Activo"
            };
            var productList = new List<Product> { product };
            _mockProductRepository.Setup(x => x.GetProductAsync()).ReturnsAsync(productList);

            //Act
            var result = await _mockProductRepository.Object.GetProductAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(productList, result);
        }

        [Fact]
        public async Task CreateProductAsync()
        {
            //Arrange
            var newProduct = new Product
            {
                Id_Store = 1,
                Names = "Leche",
                Description = "Lacteos",
                Stock = 10,
                Price = 1000,
                AdmissionDate = DateTime.Now,
                DepartureDate = null,
                State = "Activo"
            };
            var productCreated = new NewProduct
            {
                Id_Store = 1,
                Names = "Leche",
                Description = "Lacteos",
                Stock = 10,
                Price = 1000,
                AdmissionDate = DateTime.Now,
                DepartureDate = null,
                State = "Activo"
            };
            _mockProductRepository.Setup(x => x.CreateProductAsync(newProduct)).ReturnsAsync(productCreated);

            //Act
            var result = await _mockProductRepository.Object.CreateProductAsync(newProduct);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(productCreated, result);
        }           

        [Fact]

        public async Task GetProductByIdAsync()
        {
            //Arrange
            var product = new Product
            {
                Id_Store = 1,
                Names = "Leche",
                Description = "Lacteos",
                Stock = 10,
                Price = 1000,
                AdmissionDate = DateTime.Now,
                DepartureDate = null,
                State = "Activo"
            };
            var productId = new Product();
            _mockProductRepository.Setup(x => x.GetProductByIdAsync(1)).ReturnsAsync(productId);

            //Act
            var result = await _mockProductRepository.Object.GetProductByIdAsync(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(productId, result);
        }
    }
}
