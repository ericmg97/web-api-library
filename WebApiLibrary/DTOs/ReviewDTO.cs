using WebApiLibrary.Models;

namespace WebApiLibrary.DTOs
{
    public class ReviewDTO
    {
        public EnumCalificacion Calificacion { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
    }
}
