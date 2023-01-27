using Microsoft.EntityFrameworkCore;
using StudyCaseWebApp.DAL.Models;
using Microsoft.Extensions.Configuration;

namespace DAL.Contexts
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
