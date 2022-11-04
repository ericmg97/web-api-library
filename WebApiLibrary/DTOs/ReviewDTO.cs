using WebApiLibrary.Models;

namespace WebApiLibrary.DTOs
{
    public class ReviewDTO
    {
        public string EmailUsuario { get; set; }
        public EnumCalificacion Calificacion { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
    }
}
