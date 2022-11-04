using System.ComponentModel.DataAnnotations;

namespace WebApiLibrary.Models
{
    public enum EnumCalificacion
    {
        MuyMala = 1,
        Mala,
        Regular,
        Buena,
        MuyBuena
    }

    public class Review
    {
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }
        [EnumDataType(typeof(EnumCalificacion), ErrorMessage = $"Las calificaciones deben estar entre 1 y 5 estrellas.")]
        public EnumCalificacion Calificacion { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }
    }
}
