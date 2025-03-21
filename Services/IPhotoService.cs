using MediaApi.Models;
using MediaApi.Repository;

namespace MediaApi.Services
{
    public interface IPhotoService
    {
        public Task<Photo> AddPhoto(Photo photo);
        public Task<IEnumerable<Photo>> GetPhotos(int albumId);

        public  Task DeletePhoto(int photoId);
    }
}
