using MediaApi.DTOs;

namespace MediaApi.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumDto>> GetAlbumsByUser(int id);

        Task<AlbumDto> AddAlbum(AlbumInsertDto album);
    }
}
