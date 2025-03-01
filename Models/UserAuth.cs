using System.ComponentModel.DataAnnotations;

namespace MediaApi.Models
{
    public class UserAuth
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
    }
}
