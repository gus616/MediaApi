using MediaApi.Models;

namespace MediaApi.Services
{
    public class UserService : UserInterface
    {
        public Task<User> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
