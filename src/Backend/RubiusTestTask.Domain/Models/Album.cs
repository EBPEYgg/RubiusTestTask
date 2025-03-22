using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RubiusTestTask.Domain.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ReleaseYear { get; set; }

        [ForeignKey("Musician")]
        public int MusicianId { get; set; }

        public Musician Musician { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}