using Microsoft.EntityFrameworkCore;
using UniTestSt5.Models;

namespace UniTestSt5.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
        public DbSet<Category> Category { get; set; }
    }
}
