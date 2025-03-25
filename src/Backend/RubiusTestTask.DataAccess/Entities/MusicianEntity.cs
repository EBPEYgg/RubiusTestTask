using System.ComponentModel.DataAnnotations;

namespace RubiusTestTask.DataAccess.Entities
{
    /// <summary>
    /// Класс, описывающий музкального исполнителя.
    /// </summary>
    public class MusicianEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public string? Genre { get; set; }

        public int CareerStartYear { get; set; }

        public ICollection<AlbumEntity>? Albums { get; set; }
    }
}