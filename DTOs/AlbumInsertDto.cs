using Microsoft.AspNetCore.Mvc;

namespace MediaApi.DTOs
{
    public class AlbumInsertDto
    {
       public string Title { get; set; }

        public int UserId { get; set; }
    }
}
