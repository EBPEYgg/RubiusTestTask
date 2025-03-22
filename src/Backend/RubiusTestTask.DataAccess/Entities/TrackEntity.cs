using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RubiusTestTask.DataAccess.Entities
{
    public class TrackEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Duration { get; set; }

        public bool IsFavorite { get; set; }

        public bool IsListened { get; set; }

        public int Rating { get; set; } // 1 – like, -1 – dislike, 0 – нет оценки

        [ForeignKey("Album")]
        public int AlbumId { get; set; }

        public AlbumEntity? Album { get; set; }
    }
}