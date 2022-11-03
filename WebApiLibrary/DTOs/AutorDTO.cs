using System.ComponentModel.DataAnnotations;

namespace WebApiLibrary.DTOs
{
    public class AutorDTO
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Nacionalidad { get; set; }
        [Required]
        public DateTime FechaDeNacimiento { get; set; }
    }
}
