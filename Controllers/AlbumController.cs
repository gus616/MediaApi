using MediaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : Controller
    {
        public List<Album> Albums { get; set; }

        public AlbumController()
        {
            Albums = new List<Album>
                {
                    new Album { Id = 1, Title = "Album 1", UserId = 1 },
                    new Album { Id = 2, Title = "Album 2", UserId = 2 }
                };
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbums([FromQuery] int userId)
        {
            var albumList = await Task.Run(() => Albums.Where(album => album.UserId == userId).ToList());

            if (albumList == null || !albumList.Any())
            {
                return NotFound($"No albums with user:{userId}");
            }

            return Ok(albumList);
        }
    }
}
