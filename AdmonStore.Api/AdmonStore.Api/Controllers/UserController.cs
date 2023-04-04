using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdmonStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserUseCase _userUseCase;
        private readonly IMapper _mapper;


        public CustomerController(ICustomerUseCase customerUseCase, IMapper mapper)
        {
            _customerUseCase = customerUseCase;
            _mapper = mapper;
        }
    }
