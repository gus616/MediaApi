using MediaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaApi.Repository
{
    public class PhotoRepository 
    {
        private readonly MediaContext _context;
        public PhotoRepository(MediaContext context)
        {
            _context = context;
        }

        public async Task<Photo> GetById(int id) => await _context.Photos.FindAsync(id);
        public async Task Add(Photo entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Photo>> GetAll(int albumId) => await _context.Photos.Where(p => p.AlbumId == albumId).ToListAsync();
        
        public void Delete(Photo entity) => _context.Photos.Remove(entity);

        public Task Save =>  _context.SaveChangesAsync();

    }
}
