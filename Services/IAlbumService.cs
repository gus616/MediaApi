using MediaApi.DTOs;

namespace MediaApi.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumDto>> GetAllByUserId(int id);

        Task<AlbumDto> AddAlbum(AlbumInsertDto album);

        Task<bool> DeleteAlbum(int id);      
    }
}
