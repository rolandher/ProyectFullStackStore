using AdmonStore.Domain.Gateway.Repositories;
using AdmonStoreDomain.Entities.Commands;
using AdmonStoreDomain.Entities.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Test.UserRepositoryTest
{
    public class UserRepositoryTest
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        public UserRepositoryTest()
        {
            _mockUserRepository = new();
        }

        [Fact]
        public async Task CreateUser()
        {
            //arrange
            var userToCreate = new User()
            {
                Firebase_Id = "Test",
                Names = "Test",
                SurNames = "Test",
                Phone = "Test",
                Email = "",
                Gender = "Test",
                State = true

            };

            var userCreated = new NewUser
            {
                Firebase_Id = "Test",
                Names = "Test",
                SurNames = "Test",
                Phone = "Test",
                Email = "",
                Gender = "Test",
                State = true
            };

            _mockUserRepository.Setup(x => x.CreateUser(userToCreate)).ReturnsAsync(userCreated);

            //act
            var result = await _mockUserRepository.Object.CreateUser(userToCreate);

            //assert
            Assert.Equal(userCreated, result);

        }
        [Fact]
        public async Task GetUsers()
        {
            //arrange
            List<User> users = new();
            var user1 = new User
            {
                Firebase_Id = "Test",
                Names = "Test",
                SurNames = "Test",
                Phone = "Test",
                Email = "",
                Gender = "Test",
                State = true
            };

            var user2 = new User
            {
                Firebase_Id = "Test",
                Names = "Test",
                SurNames = "Test",
                Phone = "Test",
                Email = "",
                Gender = "Test",
                State = true
            };
            users.Add(user1);
            users.Add(user2);

            //act
            _mockUserRepository.Setup(x => x.GetUsers()).ReturnsAsync(users);

            //act
            var result = await _mockUserRepository.Object.GetUsers();

            //assert
            Assert.Equal(users, result);
        }

        [Fact]
        public async Task UpdateUser()
        {
            //arrange
            var userToUpdate = new User()
            {
                Firebase_Id = "Test",
                Names = "Test",
                SurNames = "Test",
                Phone = "Test",
                Email = "",
                Gender = "Test",
                State = true

            };

            var userUpdated = new User
            {
                Firebase_Id = "Test",
                Names = "Test",
                SurNames = "Test",
                Phone = "Test",
                Email = "",
                Gender = "Test",
                State = true
            };

            _mockUserRepository.Setup(x => x.UpdateUser(userToUpdate)).ReturnsAsync(userUpdated);

            //act
            var result = await _mockUserRepository.Object.UpdateUser(userToUpdate);

            //assert
            Assert.Equal(userUpdated, result);
        }
               

        [Fact]
        public async Task DeleteUser()
        {
        //    //arrange
        //    var userToDelete = new User
        //    {
        //        User_Id = "test-user-123",
        //        State = true
        //    };

        //    var 

        //    _mockUserRepository.Setup(x => x.DeleteUser(userToDelete)).ReturnsAsync(userUpdated);

        //    // act
        //    var result = await _mockUserRepository.Object.DeleteUser(userToDelete.User_Id);

        //    // assert
        //    Assert.Equal($"Delete Successful for ID: {userToDelete.User_Id}", result);
        }


    }
}
