using MediaApi.Models;

namespace MediaApi.DTOs
{
    public class PhotoDto
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public int AlbumId { get; set; }
    }
}
