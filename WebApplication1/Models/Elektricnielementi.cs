using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Elektricnielementi
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string naziv { get; set; }
        public string opis { get; set; }
        public string karakteristike { get; set; }
        public string podaci { get; set; }
    }
}
