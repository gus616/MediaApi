using Microsoft.AspNetCore.Mvc;

namespace MediaApi.DTOs
{
    public class AlbumDto 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
    }
}
