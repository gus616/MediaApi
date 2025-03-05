using MediaApi.DTOs;
using MediaApi.Models;
using MediaApi.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MediaApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthRepository _repository;
        private readonly IConfiguration _config;
        public AuthService(AuthRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _config = configuration;
        }
        public async Task<string> LoginAsync(UserLoginDto userAuthDto)
        {

            var user = await _repository.GetUserByEmailAsync(userAuthDto.Email);

            var result = new PasswordHasher<UserLoginDto>().VerifyHashedPassword(userAuthDto, user.Password, userAuthDto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return CreateJwtToken(user);            
        }

        public async Task<string> RegisterAsync(UserAuthDto userAuthDto)
        {

            userAuthDto.Password = new PasswordHasher<UserAuthDto>().HashPassword(userAuthDto, userAuthDto.Password);

            var user = await _repository.RegisterAsync(userAuthDto);
            var token = CreateJwtToken(user);
            return token;
        }


        private string CreateJwtToken(UserAuth user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("FullName", user.FullName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
              issuer: _config["Jwt:Issuer"],
              audience: _config["Jwt:Audience"],
              claims: claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
