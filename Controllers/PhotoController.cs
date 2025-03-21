using MediaApi.DTOs;
using MediaApi.Models;
using MediaApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MediaApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Photo>>> GetPhotos(int albumId)
        {
            try
            {
                 var photos = await _photoService.GetPhotos(albumId);

                if(photos.Count() == 0)
                {
                    return NoContent();
                }

                return Ok(photos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Photo>> AddPhoto(PhotoDto photo)
        {
            var newPhoto = new Photo
            {
                AlbumId = photo.AlbumId,
                Description = photo.Description,
                Url = photo.Url,
                DateAdded = DateTime.Now
            };
            try
            {
                var addedPhoto = await _photoService.AddPhoto(newPhoto);
                return Ok(addedPhoto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
