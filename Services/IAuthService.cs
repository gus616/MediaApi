using MediaApi.DTOs;
using MediaApi.Models;

namespace MediaApi.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(UserAuthDto userAuthDto);

        Task<string> LoginAsync(UserLoginDto userAuthDto);
    }
}
