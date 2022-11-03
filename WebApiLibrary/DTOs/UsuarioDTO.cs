using System.ComponentModel.DataAnnotations;

namespace WebApiLibrary.DTOs
{
    public class UsuarioDTO
    {
        [StringLength(100)]
        [Required]
        public string Nombre { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Url]
        public string Imagen { get; set; }
        public DateTime FechaRegistro { get; set; }

        public int CantidadSuscripciones { get; set; }
    }
}
