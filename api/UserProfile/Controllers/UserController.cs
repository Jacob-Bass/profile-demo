using AutoMapper;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UserProfile.Services;

namespace UserProfile.Controllers
{
    //too tired to make service
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/users")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {

            List<User> res = await _userService.GetAll();
            var users = _mapper.Map<List<User>, List<UserDTO>>(res);
            return Ok(users);
           
        }


        [HttpPost]
        public async Task<ActionResult<UserDTO>> AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newUser = await _userService.AddUser(user);
            
            return Ok(_mapper.Map<UserDTO>(newUser));

        }
    }
}
