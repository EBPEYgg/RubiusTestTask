using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RubiusTestTask.DataAccess.Entities
{
    public class AlbumEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public int ReleaseYear { get; set; }

        [ForeignKey("Musician")]
        public int MusicianId { get; set; }

        public MusicianEntity? Musician { get; set; }

        public ICollection<TrackEntity>? Tracks { get; set; }
    }
}