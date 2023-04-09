using AdmonStore.Domain2.Gateway.Repositories;
using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using AdmonStore.Infrastructure2.Gateway;
using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AdmonStore.Infrastructure2.SqlAdapter
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;
        private readonly string _tableName = "Products";        

        public ProductRepository(IDbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
        }

        public async Task<NewProduct> CreateProductAsync(Product product)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var producToCreate = new Product
            {
                Id_Store = product.Id_Store,
                Names = product.Names,
                Description = product.Description,
                Stock = product.Stock,
                Price = product.Price,
                AdmissionDate = DateTime.Now,
                DepartureDate = null,
                State = true
            };

            Product.Validate(producToCreate);

            string sqlQuery = $"INSERT INTO {_tableName} (Id_Store, Names, Description, Stock, Price, AdmissionDate, DepartureDate, State)" +
                $"VALUES (@Id_Store, @Names, @Description, @Stock, @Price, @AdmissionDate, @DepartureDate, @State)";

            var result = await connection.ExecuteScalarAsync(sqlQuery, producToCreate);
            connection.Close();
            return _mapper.Map<NewProduct>(producToCreate);
        }

    
        public async Task<List<Product>> GetProductAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {_tableName}";
            var products = await connection.QueryAsync<Product>(sqlQuery);            

            connection.Close();
            return products.ToList();

        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {_tableName} WHERE Product_Id = @id";
            var product = await connection.QueryFirstOrDefaultAsync<Product>(sqlQuery, new { id = id });

            connection.Close();
            return product;
            
        }

        public async Task<Product> AgregateStockProductAsync(StockProduct stockProduct)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var productStockUpdate = await GetProductByIdAsync(stockProduct.Product_Id);
            productStockUpdate.Stock += stockProduct.Stock;                    

            string sqlQuery = $"UPDATE {_tableName} SET Stock = @Stock, DepartureDate = @DepartureDate WHERE Product_Id = @Product_Id";

            var result = await connection.ExecuteAsync(sqlQuery, productStockUpdate);

            connection.Close();
            return _mapper.Map<Product>(productStockUpdate);


        }

        public async Task<Product> SubtractStockProductAsync(StockProduct stockProduct)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            var productStockUpdate = await GetProductByIdAsync(stockProduct.Product_Id);           

            if (stockProduct.Stock > productStockUpdate.Stock)
            {
                throw new InvalidOperationException("No hay suficiente stock disponible.");
            }
           
            productStockUpdate.Stock -= stockProduct.Stock;

            string sqlQuery = $"UPDATE {_tableName} SET Stock = @Stock, DepartureDate = @DepartureDate WHERE Product_Id = @Product_Id";

            var result = await connection.ExecuteAsync(sqlQuery, productStockUpdate);

            connection.Close();
            return _mapper.Map<Product>(productStockUpdate);
        }

        public async Task<Product> UpdateStateAsync(UpdateState updateState)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var stateToUpdate = await GetProductByIdAsync(updateState.Product_Id);

            switch (updateState.State)
            {
                case true:
                    stateToUpdate.State = true;
                    break;
                case false:
                    stateToUpdate.State = false;
                    break;

                default:
                    throw new InvalidOperationException("the status is not valid.");

            }

            string sqlQuery = $"UPDATE {_tableName} SET State = @State WHERE Product_Id = @Product_Id";
            var result = await connection.ExecuteAsync(sqlQuery, stateToUpdate);
            connection.Close();
            return _mapper.Map<Product>(stateToUpdate);
        }       
    }
}
