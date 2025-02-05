using MediaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public List<User> Users { get; set; }

        public UserController()
        {
            Users = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "", Age = 30 },
                new User { Id = 2, Name = "Gus Vc", Email= "", Age =35 }
            };
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {

            return Users;
        }

        [HttpGet("{id}")]
        public async Task<User> GetUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        [HttpPost]
        public async Task<User> AddUser(User user)
        {
            Users.Add(user);
            return user;
        }
    }
}
