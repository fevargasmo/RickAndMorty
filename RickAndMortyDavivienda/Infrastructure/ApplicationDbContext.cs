using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Character> Character { get; set; }
        public DbSet<Location> Location { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>().HasOne(c => c.Origin).WithMany()
                .HasForeignKey(d => d.OriginId);

            modelBuilder.Entity<Character>().HasOne(c => c.Location).WithMany()
                .HasForeignKey(d => d.LocationId);
        }
    }
}
