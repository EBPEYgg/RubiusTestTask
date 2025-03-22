using System.ComponentModel.DataAnnotations;

namespace RubiusTestTask.DataAccess.Entities
{
    public class MusicianEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public string? Genre { get; set; }

        public int CareerStartYear { get; set; }

        public ICollection<AlbumEntity>? Albums { get; set; }
    }
}