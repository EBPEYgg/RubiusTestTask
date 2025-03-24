using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RubiusTestTask.Domain.Models
{
    public class Track
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Duration { get; set; }

        public bool IsFavorite { get; set; }

        public bool IsListened { get; set; }

        public int Rating { get; set; } // 1 – like, -1 – dislike, 0 – нет оценки

        [ForeignKey("Album")]
        public long AlbumId { get; set; }
    }
}