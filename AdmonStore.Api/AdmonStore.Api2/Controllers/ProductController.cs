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
    }
}
