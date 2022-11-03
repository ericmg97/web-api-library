using System.ComponentModel.DataAnnotations;
using WebApiLibrary.Models;

namespace WebApiLibrary.DTOs
{
    public class LibroCreacionDTO
    {
        [StringLength(100)]
        [Required]
        public string Titulo { get; set; }
        [StringLength(50)]
        [Required]
        public string NombreEditorial { get; set; }
        [Required]
        public int CantidadDePaginas { get; set; }
        [Required]
        public DateTime FechaDePublicacion { get; set; }
        [Url]
        [Required]
        public string URLDescarga { get; set; }
        [RegularExpression("^[0-9]*$")]
        [MinLength(7)]
        [Required]
        public string ISBN { get; set; }
    }
}
