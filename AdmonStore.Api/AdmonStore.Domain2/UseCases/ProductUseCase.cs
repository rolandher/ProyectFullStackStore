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
    public class ProductUseCase : IProductUseCase
    {
        private readonly IProductRepository _productRepository;
        public ProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<NewProduct> CreateProductAsync(Product product)
        {
            return await _productRepository.CreateProductAsync(product);
        }

        public async Task<List<Product>> GetProductAsync()
        {
            return await _productRepository.GetProductAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<Product> UpdateStockProductAsync(Product product)
        {
            return await _productRepository.UpdateStockProductAsync(product);
        }
        
    }
}
