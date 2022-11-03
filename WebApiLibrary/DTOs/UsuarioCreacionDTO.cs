using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApiLibrary.DTOs
{
    public class UsuarioCreacionDTO
    {
        [StringLength(100)]
        [Required]
        public string Nombre { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public IFormFile Imagen { get; set; }
    }
}
