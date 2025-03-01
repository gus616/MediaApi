using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace MediaApi.Models
{
    public class MediaContext : IdentityDbContext<ApplicationUser>
    {
        public MediaContext(DbContextOptions<MediaContext> options) : base(options) { }

        public new DbSet<User> Users { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<UserAuth> UserAuths { get; set; }
    }
}
