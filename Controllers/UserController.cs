using FluentValidation;
using MediaApi.DTOs;
using MediaApi.Models;
using MediaApi.Services;
using MediaApi.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        
        [HttpGet("GetUsers")]
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
                return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {

            UserDto user = await _userService.GetUser(id);

            if (user is null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "User not found",
                    Detail = $"User with id {id} was not found"
                });
        }
            try
            {
                var result = await _userService.DeleteUser(id);
                if (result)
                {
                    return NoContent();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Item could not be deleted");

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
       
        }
    }
}
