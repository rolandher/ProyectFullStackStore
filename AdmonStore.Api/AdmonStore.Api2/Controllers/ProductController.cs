using AdmonStore.Domain2.Gateway;
using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdmonStore.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductUseCase _productUseCase;
        private readonly IMapper _mapper;


        public ProductController(IProductUseCase productUseCase, IMapper mapper)
        {
            _productUseCase = productUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<NewProduct> CreateProductAsync([FromBody] NewProduct newProduct)
        {
            return await _productUseCase.CreateProductAsync(_mapper.Map<Product>(newProduct));
        }

        [HttpGet]
        public async Task<List<Product>> GetProductAsync()
        {
            return await _productUseCase.GetProductAsync();
        }

        [HttpGet]
        [Route("GetProductById")]
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productUseCase.GetProductByIdAsync(id);
        }

    }
}
