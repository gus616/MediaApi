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

        public void Delete(Album entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Album>> GetAll() => await _context.Albums.ToListAsync();

        public async Task<IEnumerable<Album>> GetAllAlbumByUserId(int userId) => await _context.Albums.Where(a => a.UserId == userId).ToListAsync();

        public Task<Album> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

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
