using AdmonStore.Domain.Gateway;
using AdmonStoreDomain.Entities.Commands;
using AdmonStoreDomain.Entities.Entities;
using AdmonStoreDomain.Entities.Query;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdmonStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserUseCase _userUseCase;
        private readonly IMapper _mapper;


        public UserController(IUserUseCase userUseCase, IMapper mapper)
        {
            _userUseCase = userUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<GetUser>> Get_List_User()
        {
            return await _userUseCase.GetListUsers();
        }

        [HttpPost]
        public async Task<User> Create_User([FromBody] NewUser command)
        {
            return await _userUseCase.AddUser(_mapper.Map<User>(command));
        }
    }
}
