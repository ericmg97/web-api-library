using System.ComponentModel.DataAnnotations;

namespace WebApiLibrary.DTOs
{
    public class AutorDTO
    {
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public List<LibroAutorDTO> Libros { get; set; }
        public int CantidadSuscriptores { get; set; }
    }
}
