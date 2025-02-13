using MediaApi.DTOs;
using MediaApi.Models;
using MediaApi.Repository;

namespace MediaApi.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> AddUser(UserInsertDto user)
        {
            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Age = user.Age
            };

            await _userRepository.Add(newUser);
            await _userRepository.Save();

            return new UserDto
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email,
                Age = newUser.Age
            };
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return false;
            }
            _userRepository.Delete(user);
            await _userRepository.Save();
            return true;
        }


        public async Task<UserDto> GetUser(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return null;
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Age = user.Age
            };

            return userDto;
        }    

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var listOfUsers = await _userRepository.GetAll();

            return listOfUsers.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Age = user.Age
            });            
        }

        public Task<UserDto> UpdateUser(int id, UserInsertDto user)
        {
            throw new NotImplementedException();
        }
    }
}
