using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApiLibrary.Models
{
    [Index(propertyNames: nameof(ISBN), IsUnique = true)]
    public class Libro
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Titulo { get; set; }
        public int AutorId { get; set; }   
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
        public int PromedioCalificacion { get; set; }
        public Autor Autor { get; set; }
    }
}
