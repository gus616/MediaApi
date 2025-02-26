using System.ComponentModel.DataAnnotations;

namespace MediaApi.DTOs
{
    public class SignUpDto
    {
        [Required]
        [MinLength(5)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
