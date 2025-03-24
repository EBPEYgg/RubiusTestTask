using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RubiusTestTask.Domain.Models
{
    public class Album
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public int ReleaseYear { get; set; }

        [ForeignKey("Musician")]
        public long MusicianId { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}