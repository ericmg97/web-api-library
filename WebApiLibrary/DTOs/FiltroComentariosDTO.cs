using WebApiLibrary.Models;

namespace WebApiLibrary.DTOs
{
    public class FiltroComentariosDTO : PaginacionDTO
    {
        public EnumCalificacion? reviewType { get; set; } = null;

        public bool? sort { get; set; } = null;
    }
}
