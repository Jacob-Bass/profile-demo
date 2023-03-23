using AutoMapper;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserProfile;
using UserProfile.Controllers;
using UserProfile.Services;

namespace UserProfileTest
{
    public class UserProfileTest
    {
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserProfileTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();

            var options = new DbContextOptionsBuilder<UserContext>()
            .UseInMemoryDatabase(databaseName: "UserTestDB")
            .Options;
            _userContext = new UserContext(options);

            _userContext.Users.AddRange(
                new List<User>()
                {
                    new User
                    {
                        UserId = new Guid(),
                        FirstName = "Testy",
                        LastName = "McTesterson",
                        Email = "testemail@email.com",
                        UserName = "testUser1",
                        Password = "securePass!12"
                    },
                     new User
                    {
                        UserId = new Guid(),
                        FirstName = "MsTesty",
                        LastName = "MsTesterson",
                        Email = "testemail2@email.com",
                        UserName = "testUser2",
                        Password = "securePass!12"
                    }
                }
            );

            _userContext.SaveChanges();

            _userService = new UserService( _userContext );
        }

        [Fact]
        public async void GetAll_WhenCalled_ReturnsResult()
        {

            var users = await _userService.GetAll();

            Assert.NotEmpty(users);
        }

        [Fact]
        public async void Add_ValidObjectPassed_ReturnsUser()
        {

            var newUser = new User { 
                FirstName = "ANewUser",
                LastName = "aLastName",
                Email = "aTestEmail@gmail.com",
                UserName = "aUserNameThisIs",
                Password = "APasswordThatWorks!12"
            };

            
            var addedUser = await _userService.AddUser( newUser );
            var lookupUser = _userContext.Users
                .FirstOrDefault(u => u.FirstName == newUser.FirstName && newUser.Email == u.Email);

            Assert.True(addedUser.UserId == lookupUser.UserId);
        }


    }


}


