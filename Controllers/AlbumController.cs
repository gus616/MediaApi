using FluentValidation;
using MediaApi.DTOs;
using MediaApi.Models;
using MediaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : Controller
    {

        private readonly IAlbumService _albumService;
        private readonly IValidator<AlbumInsertDto> _albumInsertValidator;

        public AlbumController(IAlbumService albumService, IValidator<AlbumInsertDto> albumInsertValidator)
        {
            _albumService = albumService;
            _albumInsertValidator = albumInsertValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbums([FromQuery] int userId)
        {
            var albums = await _albumService.GetAllByUserId(userId);

            return Ok(albums);
        }

        [HttpPost]
        public async Task<IActionResult> AddAlbum([FromBody] AlbumInsertDto album)
        {

            var validationResult = _albumInsertValidator.Validate(album);
            if (!validationResult.IsValid) 
            {
                return BadRequest(validationResult.Errors);
            }

            var newAlbum = await _albumService.AddAlbum(album);
            return CreatedAtAction(nameof(GetAlbums), new { userId = newAlbum.UserId }, newAlbum);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            await _albumService.DeleteAlbum(id);
            return Ok();
        }
    }
}
