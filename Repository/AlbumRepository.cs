using MediaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaApi.Repository
{
    public class AlbumRepository : IRepository<Album>
    {
        private readonly MediaContext _context;

        public AlbumRepository(MediaContext context)
        {
            _context = context;
        }

        public async Task Add(Album album)
        {
            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();
        }

        public void Delete(Album album) =>  _context.Albums.Remove(album);

        public async Task<IEnumerable<Album>> GetAll() => await _context.Albums.ToListAsync();

        public async Task<IEnumerable<Album>> GetAllByUserId(int userId) => await _context.Albums.Where(a => a.UserId == userId).ToListAsync();

        public Task<Album> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save() => _context.SaveChangesAsync();

        public IEnumerable<Album> Search(Func<Album, bool> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Album entity)
        {
            throw new NotImplementedException();
        }
    }
}
