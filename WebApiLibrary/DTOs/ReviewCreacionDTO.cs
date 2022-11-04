using System.ComponentModel.DataAnnotations;
using WebApiLibrary.Models;

namespace WebApiLibrary.DTOs
{
    public class ReviewCreacionDTO
    {
        [EnumDataType(typeof(EnumCalificacion), ErrorMessage = $"Las calificaciones deben estar entre 1 y 5 estrellas.")]
        public EnumCalificacion Calificacion { get; set; }
        public string Mensaje { get; set; }
    }
}
