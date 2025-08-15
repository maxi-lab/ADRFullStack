using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DbDevContext:DbContext
    {
        public DbDevContext(DbContextOptions<DbDevContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movies");
        }

    }
}
