using Microsoft.AspNetCore.Identity;

namespace MediaApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
