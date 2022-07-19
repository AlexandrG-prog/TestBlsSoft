using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Concrete
{
    /// <summary>
    /// Контекст для работы с PostgreSQL
    /// </summary>
    public class PostgreDataContext : DbContext
    {
        public DbSet<StarSystem> StarSystems { get; set; }
        public DbSet<SpaceObject> SpaceObjects { get; set; }

        public PostgreDataContext(DbContextOptions<PostgreDataContext> options)
        : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SpaceObject>()
            .HasOne(p => p.StarSystem)
            .WithMany(t => t.SpaceObjects)
            .HasForeignKey(p => p.StarSystemId);
        }
    }
}
