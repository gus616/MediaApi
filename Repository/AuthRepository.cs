using MediaApi.DTOs;
using MediaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaApi.Repository
{
    public class AuthRepository
    {
        private readonly MediaContext _context;
        public AuthRepository(MediaContext context)
        {
            _context = context;
        }

        public async Task<UserAuth> RegisterAsync(UserAuthDto userAuthDto)
        {
            var user = new UserAuth
            {
                FullName = userAuthDto.FullName,
                Email = userAuthDto.Email,
                Password = userAuthDto.Password
            };
            await _context.UserAuths.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserAuth> GetUserByEmailAsync(string email)
        {
            var user = await _context.UserAuths.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}
