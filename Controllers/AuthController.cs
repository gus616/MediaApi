using MediaApi.DTOs;
using MediaApi.Models;
using MediaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace MediaApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly IConfiguration _config;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration config, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAuthService authService)
        {
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserAuthDto request)
        {
            try 
            {
                var token = await _authService.RegisterAsync(request);
                if (token == null)
                {
                    return BadRequest();
                }


                return Ok(new {token});
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }          
        }

        [HttpPost("loginUser")]
        public async Task<IActionResult> LoginUser(UserLoginDto request)
        {
            var user = await _authService.LoginAsync(request);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(new { token = user });
        }
       
    }
}
