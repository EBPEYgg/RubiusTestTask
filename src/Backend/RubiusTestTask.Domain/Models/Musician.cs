using System.ComponentModel.DataAnnotations;

namespace RubiusTestTask.Domain.Models
{
    public class Musician
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public string? Genre { get; set; }

        public int CareerStartYear { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}