using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RubiusTestTask.DataAccess.Entities
{
    public class AlbumEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public int ReleaseYear { get; set; }

        [ForeignKey("Musician")]
        public long MusicianId { get; set; }

        public ICollection<TrackEntity>? Tracks { get; set; }
    }
}