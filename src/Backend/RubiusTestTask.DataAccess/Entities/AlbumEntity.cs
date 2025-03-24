using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RubiusTestTask.DataAccess.Entities
{
    public class AlbumEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; } = null!;

        [Range(0, Double.MaxValue, ErrorMessage = "Year must not be a negative value.")]
        public int ReleaseYear { get; set; }

        [ForeignKey("Musician")]
        public long MusicianId { get; set; }

        public ICollection<TrackEntity>? Tracks { get; set; }
    }
}