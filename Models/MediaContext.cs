using Microsoft.EntityFrameworkCore;
using System;

namespace MediaApi.Models
{
    public class MediaContext : DbContext
    {
        public MediaContext(DbContextOptions<MediaContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }  
    }
}
