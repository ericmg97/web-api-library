using System.ComponentModel.DataAnnotations;

namespace WebApiLibrary.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Nombre { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Url]
        public string Imagen { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<Autor> Suscripciones { get; set; }
    }
}
