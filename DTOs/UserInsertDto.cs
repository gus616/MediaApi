using Microsoft.AspNetCore.Mvc;

namespace MediaApi.DTOs
{
    public class UserInsertDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
