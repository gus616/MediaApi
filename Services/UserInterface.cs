using MediaApi.Models;

namespace MediaApi.Services
{
    public interface UserInterface
    {
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUser(int id);

        public Task<User> AddUser(User user);
    }
}
