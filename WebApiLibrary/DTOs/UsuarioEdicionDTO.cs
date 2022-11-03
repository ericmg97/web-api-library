using System.ComponentModel.DataAnnotations;

namespace WebApiLibrary.DTOs
{
    public class UsuarioEdicionDTO
    {
        [Url]
        public string Imagen { get; set; }
    }
}
