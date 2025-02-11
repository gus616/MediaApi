using FluentValidation;
using MediaApi.DTOs;
using MediaApi.Models;
using MediaApi.Services;
using MediaApi.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<UserInsertDto> _userInsertValidator;
        public List<User> Users { get; set; }

        public UserController(IUserService userService, IValidator<UserInsertDto> userInsertValidator)
        {
          _userService = userService;
          _userInsertValidator = userInsertValidator;
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
           var validationResult = _userInsertValidator.Validate(user);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }


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
