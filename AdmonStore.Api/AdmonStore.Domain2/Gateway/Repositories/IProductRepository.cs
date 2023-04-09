using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Domain2.Gateway.Repositories
{
    public interface IProductRepository
    {
        Task<NewProduct> CreateProductAsync(Product product);
        Task<List<Product>> GetProductAsync();

        Task<Product> GetProductByIdAsync(int id);

        Task<Product> UpdateStockProductAsync(Product product);
    }
}
