using Microsoft.EntityFrameworkCore;
using RubiusTestTask.DataAccess.Entities;

namespace RubiusTestTask.DataAccess.Data
{
    public class MusicDbContext : DbContext
    {
        public DbSet<MusicianEntity> Musicians { get; set; }

        public DbSet<AlbumEntity> Albums { get; set; }

        public DbSet<TrackEntity> Tracks { get; set; }

        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackEntity>()
                .ToTable(t => t.HasCheckConstraint("CK_Track_Rating", "\"Rating\" IN (-1, 0, 1)"));

            base.OnModelCreating(modelBuilder);
        }
    }
}