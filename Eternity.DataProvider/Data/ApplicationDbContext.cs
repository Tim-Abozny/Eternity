using Eternity.DataProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace Eternity.DataProvider.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Key> Keys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
 