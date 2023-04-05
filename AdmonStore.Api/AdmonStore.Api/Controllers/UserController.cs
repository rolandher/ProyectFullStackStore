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
        public async Task<List<User>> GetUserAsync()
        {
            return await _userUseCase.GetUsers();
        }

        [HttpPost]
        public async Task<NewUser> CreateUserAsync([FromBody] NewUser newUser)
        {
            return await _userUseCase.CreateUser(_mapper.Map<User>(newUser));
        }

        [HttpPut]
        public async Task<User> UpdateUserAsync([FromBody] User user)
        {
            return await _userUseCase.UpdateUser(user);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteUserAsync(string id)
        {
            return await _userUseCase.DeleteUser(id);
        }
    }
}
