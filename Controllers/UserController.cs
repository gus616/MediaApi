using MediaApi.DTOs;
using MediaApi.Models;
using MediaApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public List<User> Users { get; set; }

        public UserController(IUserService userService)
        {
          _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {

          var users = await _userService.GetUsers();
           
          return users;
        }

        [HttpGet("{id}")]
        public async Task<UserDto> GetUser(int id)
        {
           var user = await _userService.GetUser(id);
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUser(UserInsertDto user)
        {
           
            try
            {
                var newUser = await _userService.AddUser(user);
                return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
