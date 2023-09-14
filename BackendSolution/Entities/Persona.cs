using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Entities
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(100)]
        public string Apellidos { get; set; }
        [Required]
        public int Edad { get; set; }
        [MaxLength(25)]
        public string? Telefono { get; set; }
    }
}
