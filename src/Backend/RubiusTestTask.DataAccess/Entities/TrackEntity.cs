using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RubiusTestTask.DataAccess.Entities
{
    /// <summary>
    /// Класс, описывающий музкальное произведение.
    /// </summary>
    public class TrackEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; } = null!;

        public string? Duration { get; set; }

        public bool IsFavorite { get; set; }

        public bool IsListened { get; set; }

        public int Rating { get; set; }

        [ForeignKey("Album")]
        public long AlbumId { get; set; }
    }
}