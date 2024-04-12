using FilmoSearch_portal.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace FilmoSearch_portal.Data
{
    public class PortalContext : DbContext
    {
        public DbSet<Film> Films { get; set; } = null!;

        public DbSet<Actor> Actors { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;

        public PortalContext(DbContextOptions<PortalContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasMany(f => f.Actors).WithMany(a => a.Films)
                .UsingEntity<Role>(j => j.ToTable("Roles"));
            modelBuilder.Entity<Role>().HasKey(r => new { r.FilmId, r.ActorId });
            modelBuilder.Entity<Role>().ToTable("Roles");
        }/**/
    }
}
