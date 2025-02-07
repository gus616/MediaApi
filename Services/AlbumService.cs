using MediaApi.DTOs;
using MediaApi.Models;
using MediaApi.Repository;

namespace MediaApi.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IRepository<Album> _albumRepository;

        public AlbumService(IRepository<Album> albumRepository)
        {
            _albumRepository = albumRepository;
        }
        public async Task<AlbumDto> AddAlbum(AlbumInsertDto album)
        {
            var newAlbum = new Album
            {
                Title = album.Title,
                UserId = album.UserId
            };

            await _albumRepository.Add(newAlbum);

            return new AlbumDto
            {
                Id = newAlbum.Id,
                Title = newAlbum.Title,
                UserId = newAlbum.UserId
            };
        }

        public Task<IEnumerable<AlbumDto>> GetAlbumsByUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
