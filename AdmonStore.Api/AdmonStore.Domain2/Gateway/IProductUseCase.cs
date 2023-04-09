using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Domain2.Gateway
{
    public interface IProductUseCase
    {
        Task<NewProduct> CreateProductAsync(Product product);
        Task<List<Product>> GetProductAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> UpdateStateAsync(UpdateState updateState);
        Task<Product> AgregateStockProductAsync(StockProduct stockProduct);
        Task<Product> SubtractStockProductAsync(StockProduct stockProduct);
    }
}
