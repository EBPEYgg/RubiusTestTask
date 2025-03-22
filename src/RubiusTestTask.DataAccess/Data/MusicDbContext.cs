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
    }
}