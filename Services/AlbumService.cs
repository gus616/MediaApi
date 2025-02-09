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

        public async Task<IEnumerable<AlbumDto>> GetAllByUserId(int id)
        {
            var albumList = await _albumRepository.GetAllByUserId(id);

            return albumList.Select(a => new AlbumDto
            {
                Id = a.Id,
                Title = a.Title,
                UserId = a.UserId
            });
        }

        public async Task<bool> DeleteAlbum(int id) 
        { 

            var album = await _albumRepository.GetById(id);

            if (album == null)
            {
                return false;
            }

                _albumRepository.Delete(album);
            await _albumRepository.Save();

            return true;
        }
    }
}
