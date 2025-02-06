using MediaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediaApi.DTOs
{
    public class UserDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public List<Album> Albums { get; set; } = new List<Album>();
    }
}
