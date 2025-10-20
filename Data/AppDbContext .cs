using AutoMapperExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperExample.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
