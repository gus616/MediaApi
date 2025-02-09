using MediaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaApi.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly MediaContext _context;

        public UserRepository(MediaContext context)
        {
            _context = context;
        }

        public async Task Add(User entity) => await _context.Users.AddAsync(entity);

        public async Task<IEnumerable<User>> GetAll() => await _context.Users.ToListAsync();


        public async Task<User> GetById(int id) => await _context.Users.FindAsync(id);

        public void Update(User entity)
        {
            _context.Users.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(User entity) => _context.Users.Remove(entity);


        public Task Save() => _context.SaveChangesAsync();


        public IEnumerable<User> Search(Func<User, bool> filter) => _context.Users.Where(filter).ToList();

        public Task<IEnumerable<User>> GetAllByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
