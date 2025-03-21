using MediaApi.Models;
using MediaApi.Repository;

namespace MediaApi.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly PhotoRepository _photoRepository;

        public PhotoService(PhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
        public async Task<Photo> AddPhoto(Photo photo)
        {
            await _photoRepository.Add(photo);

            return photo;
        }

        public async Task<IEnumerable<Photo>> GetPhotos(int albumId)
        {
            var photos = await _photoRepository.GetAll(albumId);

            return photos;
        }

        public async Task DeletePhoto(int photoId)
        {
           await _photoRepository.GetById(photoId).ContinueWith(task =>
           {
               var photo = task.Result;
               _photoRepository.Delete(photo);
           });
        }
    }
}
