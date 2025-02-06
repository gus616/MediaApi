using MediaApi.DTOs;
using MediaApi.Models;

namespace MediaApi.Services
{
    public interface IUserService
    {
       public Task<IEnumerable<UserDto>> GetUsers();

        public Task<UserDto> GetUser(int id);

        public Task<UserDto> AddUser(UserInsertDto user);

        public Task<UserDto> UpdateUser(int id, UserInsertDto user);

        public Task<bool> DeleteUser(int id);
    }
}
