using System.ComponentModel.DataAnnotations;

namespace RubiusTestTask.Domain.Models
{
    public class Musician
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Genre { get; set; }

        public int CareerStartYear { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}