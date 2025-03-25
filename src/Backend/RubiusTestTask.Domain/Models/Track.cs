using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RubiusTestTask.Domain.Models
{
    /// <summary>
    /// Класс, описывающий музыкальное произведение.
    /// </summary>
    public class Track
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Duration { get; set; }

        public bool IsFavorite { get; set; }

        public bool IsListened { get; set; }

        public int Rating { get; set; }

        [ForeignKey("Album")]
        public long AlbumId { get; set; }
    }
}