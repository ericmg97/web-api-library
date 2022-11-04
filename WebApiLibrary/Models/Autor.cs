using System.ComponentModel.DataAnnotations;

namespace WebApiLibrary.Models
{
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Nacionalidad { get; set; }
        [Required]
        public DateTime FechaDeNacimiento { get; set; }
        public List<Libro> Libros { get; set; }
        public List<Usuario> UsuariosSuscritos { get; set; }

    }
}
