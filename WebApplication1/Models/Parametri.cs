using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Parametri
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float povrsina_presjeka { get; set; }
        public float otpor_vodica{ get; set; }

    }
}
