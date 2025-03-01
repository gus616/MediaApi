using MediaApi.DTOs;
using MediaApi.Models;

namespace MediaApi.Services
{
    public interface IAuthService
    {
        Task<UserAuth> RegisterAsync(UserAuthDto userAuthDto);

        Task<string> LoginAsync(UserLoginDto userAuthDto);
    }
}
